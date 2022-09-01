using MySql.Data.MySqlClient;
using Server.Classi;
using System;
using System.Collections.Generic;
using System.Data;

namespace Server
{
    public class ECommerce : IECommerce
    {

        private static string connection_string = "datasource=localhost;port=3306;username=root;password=;database=e-commerce;";

        public (User, string) register(string username, string email, string password)
        {
            // Default values
            User ret = null;
            string ret2 = "";

            // Connect to the database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check if user already registered
                // We only need to do it once since Read returns one result which will be the existing account
                using (MySqlCommand command = new MySqlCommand("SELECT EMAIL FROM utenti WHERE EMAIL = '" + email + "' LIMIT 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        if (resultSet.Read())
                        {
                            throw new Exception("Utente già registrato");
                        }
                    }
                }

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand("INSERT INTO utenti (USER,EMAIL,PASSWORD,ADMIN) VALUES ('" + username + "','" + email + "','" + password + "','" + 0 + "');", conn))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ret = new User
                        {
                            user_id = Convert.ToInt32(command.LastInsertedId),
                            username = username,
                            email = email,
                            password = password,
                            admin = false,
                        };
                    }
                    else
                    {
                        throw new Exception("Registrazione fallita");
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // Close the connection if it has been opened
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret, ret2);
        }

        public (User, string) login(string email, string password)
        {
            // Default user to NULL
            User ret = null;
            string ret2 = "";

            // Connect to database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check if user and password combo matches
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM utenti WHERE EMAIL = '" + email + "'AND PASSWORD = '" + password + "' LIMIT 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Fill user if found
                        if (resultSet.Read())
                        {
                            ret = new User
                            {
                                user_id = Convert.ToInt32(resultSet.GetValue(0)),
                                username = Convert.ToString(resultSet.GetValue(1)),
                                email = Convert.ToString(resultSet.GetValue(2)),
                                password = Convert.ToString(resultSet.GetValue(3)),
                                admin = Convert.ToBoolean(resultSet.GetValue(4)),
                            };
                        }
                        else
                        {
                            throw new Exception("Login fallito!");
                        }
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret, ret2);
        }

        public (List<Product>, string) viewProducts(bool admin, int page)
        {
            // Default return value
            List<Product> ret1 = new List<Product>();
            string ret2 = "";

            // Limit the returned entries to 11 with the given offset
            // This is in order to detect whether a next page is required
            string command_string = $"SELECT * FROM smartphone ORDER BY ID LIMIT {page * 12}, 13";

            // Connect to database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Execute query
                using (MySqlCommand command = new MySqlCommand(command_string, conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Fill the list line by line
                        while (resultSet.Read())
                        {

                            // If the available quantity is zero and the user is not an admin, do not add the product to the list
                            int quantity = Convert.ToInt32(resultSet.GetValue(12));
                            if (quantity > 0 || admin)
                            {
                                Product product = new Product()
                                {
                                    product_id = Convert.ToInt32(resultSet.GetValue(0)),
                                    brand = Convert.ToString(resultSet.GetValue(1)),
                                    model = Convert.ToString(resultSet.GetValue(2)),
                                    cpu = Convert.ToString(resultSet.GetValue(3)),
                                    storage = Convert.ToInt32(resultSet.GetValue(4)),
                                    battery = Convert.ToInt32(resultSet.GetValue(5)),
                                    ram = Convert.ToInt32(resultSet.GetValue(6)),
                                    os = Convert.ToString(resultSet.GetValue(7)),
                                    camera = Convert.ToDouble(resultSet.GetValue(8)),
                                    display = Convert.ToDouble(resultSet.GetValue(9)),
                                    sim_count = Convert.ToInt32(resultSet.GetValue(10)),
                                    price = Convert.ToDecimal(resultSet.GetValue(11)),
                                    quantity = quantity
                                };
                                ret1.Add(product);
                            }
                        }
                    }
                }

                // If count is zero, show an error message
                if (ret1.Count == 0)
                {
                    throw new Exception("Nessun prodotto disponibile!");
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret1, ret2);
        }

        public (int, string) addProduct(Product product)
        {
            // Default values
            int ret = -1;
            string ret2 = "";

            // Connect to the database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand("INSERT INTO smartphone (MARCA,MODELLO,PROCESSORE,MEMORIA,BATTERIA,RAM,OS,FOTOCAMERA,DISPLAY,SIM,PREZZO,QUANTITA) VALUES ('"
                    + product.brand + "','" + product.model + "','" + product.cpu + "','" + product.storage.ToString() + "','" + product.battery.ToString() + "','" + product.ram.ToString() + "','" + product.os + "','" + product.camera.ToString()
                    + "','" + product.display.ToString() + "','" + product.sim_count.ToString() + "','" + product.price.ToString() + "','" + product.quantity.ToString() + "');", conn))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ret = Convert.ToInt32(command.LastInsertedId);
                    }
                    else
                    {
                        throw new Exception("Aggiunta prodotto fallita");
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // Close the connection if it has been opened
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret, ret2);
        }

        public (Product, string) viewProductDetails(int prod_id)
        {
            // Default values
            Product ret = null;
            string ret2 = "";

            // Connect to the database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM smartphone WHERE ID = '{prod_id}' LIMIT 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Fill user if found
                        if (resultSet.Read())
                        {
                            ret = new Product
                            {
                                product_id = Convert.ToInt32(resultSet.GetValue(0)),
                                brand = Convert.ToString(resultSet.GetValue(1)),
                                model = Convert.ToString(resultSet.GetValue(2)),
                                cpu = Convert.ToString(resultSet.GetValue(3)),
                                storage = Convert.ToInt32(resultSet.GetValue(4)),
                                battery = Convert.ToInt32(resultSet.GetValue(5)),
                                ram = Convert.ToInt32(resultSet.GetValue(6)),
                                os = Convert.ToString(resultSet.GetValue(7)),
                                camera = Convert.ToDouble(resultSet.GetValue(8)),
                                display = Convert.ToDouble(resultSet.GetValue(9)),
                                sim_count = Convert.ToInt32(resultSet.GetValue(10)),
                                price = Convert.ToDecimal(resultSet.GetValue(11)),
                                quantity = Convert.ToInt32(resultSet.GetValue(12))
                            };
                        }
                        else
                        {
                            throw new Exception("Login fallito!");
                        }
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret, ret2);
        }

        public (bool, string) createCart(int prod_id, int user_id, int quantity)
        {
            // Default values
            bool ret = false;
            string ret2 = "";

            int available = 0, prevquantity = 0, cartid = -1;
            bool create_new = true;

            // Connect to the database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand($"SELECT ID, QUANTITA FROM smartphone WHERE ID = '{prod_id}' LIMIT 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Fill user if found
                        if (resultSet.Read())
                        {
                            available = Convert.ToInt32(resultSet.GetValue(1));
                            if (quantity > available)
                            {
                                throw new Exception("La quantità selezionata eccede i pezzi disponibili!");
                            }
                        }
                        else
                        {
                            throw new Exception("Aggiunta al carrello fallita!");
                        }
                    }
                }

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM cart WHERE USERID = '{user_id}' AND PRODUCTID = '{prod_id}' LIMIT 1;", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Fill user if found
                        if (resultSet.Read())
                        {
                            cartid = Convert.ToInt32(resultSet.GetValue(0));
                            prevquantity = Convert.ToInt32(resultSet.GetValue(3));
                            if (quantity + prevquantity > available)
                            {
                                throw new Exception("La quantità selezionata eccede i pezzi disponibili!");
                            }
                            create_new = false;
                        }
                    }
                }

                // Check passed, insert user into database and return it
                if (create_new)
                {
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO cart (USERID,PRODUCTID,QUANTITY) VALUES ('" + user_id.ToString() + "','" + prod_id.ToString() + "','" + quantity.ToString() + "');", conn))
                    {
                        if (command.ExecuteNonQuery() > 0)
                        {
                            ret = true;
                        }
                        else
                        {
                            throw new Exception("Aggiunta al carrello fallita!");
                        }
                    }
                }

                else
                {
                    using (MySqlCommand command = new MySqlCommand($"UPDATE cart SET QUANTITY = '{quantity + prevquantity}' WHERE CARTID = '{cartid}';", conn))
                    {
                        if (command.ExecuteNonQuery() > 0)
                        {
                            ret = true;
                        }
                        else
                        {
                            throw new Exception("Aggiunta al carrello fallita!");
                        }
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret, ret2);
        }

        public (List<Cart>, string) viewCarts(int user_id)
        {
            // Default values
            List<Cart> ret = new List<Cart>();
            string ret2 = "";

            // Connect to the database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM cart WHERE USERID = '{user_id}';", conn))
                {
                    using (MySqlDataReader resultSet = command.ExecuteReader())
                    {
                        // Fill the list line by line
                        while (resultSet.Read())
                        {
                            Cart cart = new Cart()
                            {
                                cart_id = Convert.ToInt32(resultSet.GetValue(0)),
                                quantity = Convert.ToInt32(resultSet.GetValue(3)),
                                product_id = Convert.ToInt32(resultSet.GetValue(2)),
                                product = null
                            };

                            ret.Add(cart);
                        }
                    }
                }

                // If count is zero, show an error message
                if (ret.Count == 0)
                {
                    throw new Exception("Nessun prodotto nel carrello!");
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            // For each element, fill in the relevant product
            foreach(Cart item in ret)
            {
                var result = viewProductDetails(item.product_id);
                if (result.Item1 != null)
                {
                    item.product = result.Item1;
                }
                else
                {
                    ret.Remove(item);
                }
            }

            return (ret, ret2);
        }

        public (bool, string) removeCart(int cart_id)
        {
            // Default values
            bool ret = false;
            string ret2 = "";

            // Connect to the database
            MySqlConnection conn = new MySqlConnection(connection_string);
            try
            {
                conn.Open();

                // Check passed, insert user into database and return it
                using (MySqlCommand command = new MySqlCommand($"DELETE FROM cart WHERE CARTID = '{cart_id}';", conn))
                {
                    ret = Convert.ToBoolean(command.ExecuteNonQuery());
                    if (!ret)
                    {
                        throw new Exception("Rimozione dal carrello fallita");
                    }
                }
            }

            // Report any error
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret2 = e.Message;
            }

            // If connection is open, close it
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return (ret, ret2);
        }

        public (bool, string) buy(string address, int zip_code, string credit_card)
        {
            // Default values
            bool ret = false;
            string ret2 = "";
            return (ret, ret2);
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
    }
}

