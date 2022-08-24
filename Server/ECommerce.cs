using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Server.Classi;

namespace Server
{
    public class ECommerce : IECommerce
    {
        public User register(User user)
        {
            // Default user to NULL
            User ret = null;

            // Connect to the database
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=e-commerce;");
            try
            {
                conn.Open();

                // Check if user already registered
                // We only need to do it once since Read returns one result which will be the existing registration
                using (MySqlCommand command = new MySqlCommand("SELECT EMAIL FROM utenti WHERE EMAIL = '" + user.email + "';", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if (resultSet.Read())
                        {
                            throw new Exception("User already exists!");
                        }
                    }
                }

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand("INSERT INTO utenti (USER,EMAIL,PASSWORD,ADMIN,PAYMENT_METHOD,INDIRIZZO) VALUES ('" + user.username + "','" + user.email + "','" + user.password + "','" + 0 + "','','')", conn))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ret = user;
                    }
                    else
                    {
                        throw new Exception("Registration failed!");
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            // Close the connection if it has been opened
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return ret;
        }

        public User login(User user)
        {
            // Default user to NULL
            User ret = null;

            // Connect to database
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=e-commerce;");
            try
            {
                conn.Open();

                // Check if user and password combo match
                using (MySqlCommand command = new MySqlCommand("SELECT USER, PASSWORD, ADMIN FROM utenti WHERE USER = '"+user.username+"'AND PASSWORD = '"+user.password+"';", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Check if user is admin if found
                        if (resultSet.Read())
                        {
                            user.admin = Convert.ToBoolean(resultSet["ADMIN"]);
                            ret = user;
                        }
                        else
                        {
                            throw new Exception("Login failed!");
                        }
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return ret;
        }

        /*public bool Prenotazione(Utente u, int idcrociera, int part)
        {
            // Dichiara variabili
            int id_utente;
            int partmax;
            double prezzo;
            bool ret = false;

            // Connessione al DB
            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbcruise;uid=root;pwd='';");
            conn.Open();

            // Creazione di una transazione che viene associata al DB
            SqlTransaction trans = conn.BeginTransaction();
            Console.WriteLine("Acquisto in corso...");
            try
            {
                using (MyMySqlCommand command2 = conn.CreateCommand())
                {
                    // Prendi l'id associato alla mail dell'utente fornito
                    command2.CommandText = "SELECT ID FROM utenti WHERE EMAIL = '" + u.email + "';";
                    MySqlDataReader resultSet = command2.ExecuteReader();

                    bool found = resultSet.Read();
                    resultSet.Close();
                    if (found)
                    {
                        // Conversione a int 
                        id_utente = Convert.ToInt32(resultSet["id_utente"]);
                    }
                    else
                    {
                        throw new Exception("Prenotazione fallita");
                    }
                }

                using (MyMySqlCommand command2 = conn.CreateCommand())
                {
                    // La transazione prende l'id della crociera 
                    command2.CommandText = "SELECT * from crociere where id_crociera = '" + idcrociera + "';";
                    var resultSet = command2.ExecuteReader();
                    
                    if (resultSet.Read())
                    {
                        //gli altri due paramentri che servono per la transazione sono il numero di persone massimo e il prezzo della crociera
                        partmax = Convert.ToInt32(resultSet["numero_persone"]);
                        prezzo = Convert.ToDouble(resultSet["prezzo"]);
                        resultSet.Close();
                    }
                    else
                    {
                        throw new Exception("Prenotazione fallita");
                    }
                }
                using (MyMySqlCommand command3 = conn.CreateCommand())
                {
                    command3.CommandText = "select Numero_Biglietti from partecipanti where fk_crociera = '" + idcrociera + "';";
                    var resultSet = command3.ExecuteReader();
                    
                    //creazione di una lista di partecipanti
                    List<int> listapartecipanti = new List<int>();
                    while (resultSet.Read())
                    {
                        //Vengono aggiunti nella lista appena creata tutti i biglietti associati ai partecipanti scorrendo riga per riga 
                        listapartecipanti.Add(Convert.ToInt32(resultSet["Numero_Biglietti"]));

                    }
                    resultSet.Close();
                    //controllo del num dei partecipanti 
                    if (listapartecipanti.Sum() + part > partmax)
                    {
                        throw new Exception("Non ci sono posti a sufficienza");

                    }
                }
                // Start a local transaction               
                using (MyMySqlCommand command2 = conn.CreateCommand())
                {
                    //dopo i controlli vengono aggiunti alla tabella partecipanti i nuovi partecipanti
                    command2.Transaction = myTrans;
                    command2.CommandText = "INSERT INTO partecipanti (fk_crociera,fk_utente,Numero_Biglietti) VALUES ('" + idcrociera + "','" + id_utente + "','" + part + "')";
                    var resultSet = command2.ExecuteNonQuery();
                    Console.WriteLine("ExecutenonQuery");
                    if (resultSet > 0)
                    {
                        Console.WriteLine("Partecipanti ok");

                    }
                    else
                    {
                        throw new Exception("Impossibile inserire partecipante");
                    }
                }

                using (MyMySqlCommand command2 = conn.CreateCommand())
                {
                    //inserimento della nuova transazione nella tabella transazione
                    command2.Transaction = myTrans;
                    command2.CommandText = "INSERT INTO transazioni (importo,fk_utente,fk_barca,Numero_Tickets) VALUES ('" + prezzo*part + "','" + id_utente + "','" + idcrociera + "','" + part + "')";
                    var resultSet = command2.ExecuteNonQuery();
                    Console.WriteLine("ExecutenonQuery");
                    if (resultSet > 0)
                    {
                        Console.WriteLine("Transazione OK");

                    }
                    else
                    {
                        throw new Exception("Transazione fallita");
                    }
                }
                // Se tutto è ok, conferma i cambiamenti
                myTrans.Commit();
                ret = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                // In caso una delle operaioni fallisca, effettua un rollback
                myTrans.Rollback();
            }

            finally
            {
                conn.Close();
            }

            return ret;
        }*/

        public List<Product> viewProducts()
        {
            //creazione lista smartphone 
            List<Product> productlist = new List<Product>();

            var connectionString = "server=localhost;database=e-commerce;uid=root;pwd='';";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (MySqlCommand command2 = conn.CreateCommand())
                    {
                        command2.CommandText = "select id,marca,modello,processore,memoria,batteria,ram,os,fotocamera,display,sim,prezzo,quantità,img from smartphone;";
                        MySqlDataReader resultSet = command2.ExecuteReader();

                        while (resultSet.Read())
                        {
                            //Leggendo riga per riga aggiunge i dati nuovi dello smartphone e gli aggiunge alla lista smartphone
                            Product product = new Product();
                            product.product_id = Convert.ToInt32(resultSet["id"]);
                            product.brand = Convert.ToString(resultSet["marca"]);
                            product.model = Convert.ToString(resultSet["modello"]);
                            product.cpu = Convert.ToString(resultSet["processore"]);
                            product.storage = Convert.ToInt32(resultSet["memoria"]);
                            product.battery = Convert.ToInt32(resultSet["batteria"]);
                            product.ram = Convert.ToInt32(resultSet["ram"]);
                            product.os = Convert.ToString(resultSet["os"]);
                            product.camera = Convert.ToDouble(resultSet["fotocamera"]);
                            product.display = Convert.ToDouble(resultSet["display"]);
                            product.sim_count = Convert.ToInt32(resultSet["sim"]);
                            product.price = Convert.ToDecimal(resultSet["prezzo"]);
                            product.quantity = Convert.ToInt32(resultSet["quantita"]);
                            productlist.Add(product);

                        }

                        resultSet.Close();

                        // Se non ci sono smartphone, genera un'eccezione 
                        if (productlist.Count == 0)
                        {
                            throw new Exception("Impossibile visualizzare la lista: è vuota");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    conn.Close();
                }

                return productlist;
            }
        }

        public List<Sale> viewSales(User user)
        {
            // Crea lista
            List<Sale> ret = new List<Sale>();

            // Connetti al DB
            MySqlConnection conn = new MySqlConnection("server=localhost;database=e-commerce;uid=root;pwd='';");
            conn.Open();
            Console.WriteLine("Ricerca in corso...");

            try
            {
                using (MySqlCommand command2 = new MySqlCommand("SELECT ACQUIRENTE, DATE_FORMAT(DATA,'%d-%m-%Y'), QUANTITA, PRODOTTO FROM vendite WHERE ACQUIRENTE = '" + user.user_id + "';", conn))
                {

                    // Leggendo riga per riga, aggiungere i risultati alla lista
                    MySqlDataReader resultSet = command2.ExecuteReader();
                    while (resultSet.Read())
                    {
                        Sale sale = new Sale();
                        sale.user_id = user.user_id;
                        sale.date = Convert.ToDateTime(resultSet["DATA"]);
                        sale.quantity = Convert.ToInt32(resultSet["QUANTITA"]);
                        sale.product_id = Convert.ToInt32(resultSet["PRODOTTO"]);
                        ret.Add(sale);
                    }

                    resultSet.Close();

                    // Se non ci sono vendite, genera un'eccezione 
                    if (ret.Count == 0)
                        throw new Exception("Impossibile visualizzare la lista: è vuota");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<User> viewUsers(User caller)
        {
            //creazione lista utenti 
            List<User> userlist = new List<User>();

            string connectionString = "server=localhost;database=e-commerce;uid=root;pwd='';";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (MySqlCommand command2 = conn.CreateCommand())
                    {
                        command2.CommandText = "select id,user,email,password,admin,payment_method,indirizzo from utenti;";
                        MySqlDataReader resultSet = command2.ExecuteReader();

                        while (resultSet.Read())
                        {
                            //Leggendo riga per riga aggiunge i dati nuovi degli utenti e gli aggiunge alla lista utente
                            User user = new User();
                            user.user_id = Convert.ToInt32(resultSet["id"]);
                            user.username = Convert.ToString(resultSet["user"]);
                            user.email = Convert.ToString(resultSet["email"]);
                            user.password = Convert.ToString(resultSet["password"]);
                            user.admin = Convert.ToBoolean(resultSet["admin"]);
                            user.payment_method = Convert.ToString(resultSet["payment_method"]);
                            user.address = Convert.ToString(resultSet["indirizzo"]);
                            userlist.Add(user);

                        }

                        resultSet.Close();

                        // Se non ci sono utenti, genera un'eccezione 
                        if (userlist.Count == 0)
                        {
                            throw new Exception("Impossibile visualizzare la lista: è vuota");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    conn.Close();
                }

                return userlist;
            }
        }

        /*
        public List<Cart> viewCarts(User user)
        {
            // Creazione lista carrello 
            List<Cart> listacarrello = new List<Cart>();

            string connectionString = "server=localhost;database=e-commerce;uid=root;pwd='';";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (MySqlCommand command2 = conn.CreateCommand())
                    {
                        command2.CommandText = "SELECT * FROM cart WHERE user_id =" + user.id_utente + ";";
                        MySqlDataReader resultSet = command2.ExecuteReader();

                        while (resultSet.Read())
                        {
                            //Leggendo riga per riga aggiunge i dati nuovi degli utenti e gli aggiunge alla lista utente
                            Utente utente = new Utente();
                            utente.id_utente = Convert.ToInt32(resultSet["id"]);
                            utente.username = Convert.ToString(resultSet["user"]);
                            utente.email = Convert.ToString(resultSet["email"]);
                            utente.password = Convert.ToString(resultSet["password"]);
                            utente.admin = Convert.ToBoolean(resultSet["admin"]);
                            utente.payment_method = Convert.ToString(resultSet["payment_method"]);
                            utente.indirizzo = Convert.ToString(resultSet["indirizzo"]);
                            listautenti.Add(utente);

                        }

                        resultSet.Close();

                        // Se non ci sono utenti, genera un'eccezione 
                        if (listautenti.Count == 0)
                        {
                            throw new Exception("Impossibile visualizzare la lista: è vuota");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    conn.Close();
                }

                return listautenti;
            }
        }*/
    }
}

