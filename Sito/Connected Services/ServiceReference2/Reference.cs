﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sito.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ValueTupleOfUserstringdlgy1VAu", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.SerializableAttribute()]
    public partial struct ValueTupleOfUserstringdlgy1VAu : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Sito.ServiceReference2.User Item1Field;
        
        private string Item2Field;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public Sito.ServiceReference2.User Item1 {
            get {
                return this.Item1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Item1Field, value) != true)) {
                    this.Item1Field = value;
                    this.RaisePropertyChanged("Item1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Item2 {
            get {
                return this.Item2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Item2Field, value) != true)) {
                    this.Item2Field = value;
                    this.RaisePropertyChanged("Item2");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Server.Classi")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string addressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool adminField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string payment_methodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int user_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string address {
            get {
                return this.addressField;
            }
            set {
                if ((object.ReferenceEquals(this.addressField, value) != true)) {
                    this.addressField = value;
                    this.RaisePropertyChanged("address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool admin {
            get {
                return this.adminField;
            }
            set {
                if ((this.adminField.Equals(value) != true)) {
                    this.adminField = value;
                    this.RaisePropertyChanged("admin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string payment_method {
            get {
                return this.payment_methodField;
            }
            set {
                if ((object.ReferenceEquals(this.payment_methodField, value) != true)) {
                    this.payment_methodField = value;
                    this.RaisePropertyChanged("payment_method");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int user_id {
            get {
                return this.user_idField;
            }
            set {
                if ((this.user_idField.Equals(value) != true)) {
                    this.user_idField = value;
                    this.RaisePropertyChanged("user_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ValueTupleOfArrayOfProductstringdlgy1VAu", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.SerializableAttribute()]
    public partial struct ValueTupleOfArrayOfProductstringdlgy1VAu : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Sito.ServiceReference2.Product[] Item1Field;
        
        private string Item2Field;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public Sito.ServiceReference2.Product[] Item1 {
            get {
                return this.Item1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Item1Field, value) != true)) {
                    this.Item1Field = value;
                    this.RaisePropertyChanged("Item1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Item2 {
            get {
                return this.Item2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Item2Field, value) != true)) {
                    this.Item2Field = value;
                    this.RaisePropertyChanged("Item2");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/Server.Classi")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int batteryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string brandField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double cameraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cpuField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double displayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string modelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string osField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int product_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ramField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int sim_countField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int storageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int battery {
            get {
                return this.batteryField;
            }
            set {
                if ((this.batteryField.Equals(value) != true)) {
                    this.batteryField = value;
                    this.RaisePropertyChanged("battery");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string brand {
            get {
                return this.brandField;
            }
            set {
                if ((object.ReferenceEquals(this.brandField, value) != true)) {
                    this.brandField = value;
                    this.RaisePropertyChanged("brand");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double camera {
            get {
                return this.cameraField;
            }
            set {
                if ((this.cameraField.Equals(value) != true)) {
                    this.cameraField = value;
                    this.RaisePropertyChanged("camera");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cpu {
            get {
                return this.cpuField;
            }
            set {
                if ((object.ReferenceEquals(this.cpuField, value) != true)) {
                    this.cpuField = value;
                    this.RaisePropertyChanged("cpu");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double display {
            get {
                return this.displayField;
            }
            set {
                if ((this.displayField.Equals(value) != true)) {
                    this.displayField = value;
                    this.RaisePropertyChanged("display");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string model {
            get {
                return this.modelField;
            }
            set {
                if ((object.ReferenceEquals(this.modelField, value) != true)) {
                    this.modelField = value;
                    this.RaisePropertyChanged("model");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string os {
            get {
                return this.osField;
            }
            set {
                if ((object.ReferenceEquals(this.osField, value) != true)) {
                    this.osField = value;
                    this.RaisePropertyChanged("os");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int product_id {
            get {
                return this.product_idField;
            }
            set {
                if ((this.product_idField.Equals(value) != true)) {
                    this.product_idField = value;
                    this.RaisePropertyChanged("product_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantity {
            get {
                return this.quantityField;
            }
            set {
                if ((this.quantityField.Equals(value) != true)) {
                    this.quantityField = value;
                    this.RaisePropertyChanged("quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ram {
            get {
                return this.ramField;
            }
            set {
                if ((this.ramField.Equals(value) != true)) {
                    this.ramField = value;
                    this.RaisePropertyChanged("ram");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int sim_count {
            get {
                return this.sim_countField;
            }
            set {
                if ((this.sim_countField.Equals(value) != true)) {
                    this.sim_countField = value;
                    this.RaisePropertyChanged("sim_count");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int storage {
            get {
                return this.storageField;
            }
            set {
                if ((this.storageField.Equals(value) != true)) {
                    this.storageField = value;
                    this.RaisePropertyChanged("storage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ValueTupleOfintstring", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.SerializableAttribute()]
    public partial struct ValueTupleOfintstring : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int Item1Field;
        
        private string Item2Field;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Item1 {
            get {
                return this.Item1Field;
            }
            set {
                if ((this.Item1Field.Equals(value) != true)) {
                    this.Item1Field = value;
                    this.RaisePropertyChanged("Item1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Item2 {
            get {
                return this.Item2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Item2Field, value) != true)) {
                    this.Item2Field = value;
                    this.RaisePropertyChanged("Item2");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Sale", Namespace="http://schemas.datacontract.org/2004/07/Server.Classi")]
    [System.SerializableAttribute()]
    public partial class Sale : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int product_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int sale_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int user_idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int product_id {
            get {
                return this.product_idField;
            }
            set {
                if ((this.product_idField.Equals(value) != true)) {
                    this.product_idField = value;
                    this.RaisePropertyChanged("product_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantity {
            get {
                return this.quantityField;
            }
            set {
                if ((this.quantityField.Equals(value) != true)) {
                    this.quantityField = value;
                    this.RaisePropertyChanged("quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int sale_id {
            get {
                return this.sale_idField;
            }
            set {
                if ((this.sale_idField.Equals(value) != true)) {
                    this.sale_idField = value;
                    this.RaisePropertyChanged("sale_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int user_id {
            get {
                return this.user_idField;
            }
            set {
                if ((this.user_idField.Equals(value) != true)) {
                    this.user_idField = value;
                    this.RaisePropertyChanged("user_id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IECommerce")]
    public interface IECommerce {
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/register", ReplyAction="http://tempuri.org/IECommerce/registerResponse")]
        Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu register(string username, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/register", ReplyAction="http://tempuri.org/IECommerce/registerResponse")]
        System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu> registerAsync(string username, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/login", ReplyAction="http://tempuri.org/IECommerce/loginResponse")]
        Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu login(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/login", ReplyAction="http://tempuri.org/IECommerce/loginResponse")]
        System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu> loginAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/viewProducts", ReplyAction="http://tempuri.org/IECommerce/viewProductsResponse")]
        Sito.ServiceReference2.ValueTupleOfArrayOfProductstringdlgy1VAu viewProducts(bool admin, int offset);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/viewProducts", ReplyAction="http://tempuri.org/IECommerce/viewProductsResponse")]
        System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfArrayOfProductstringdlgy1VAu> viewProductsAsync(bool admin, int offset);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/addProduct", ReplyAction="http://tempuri.org/IECommerce/addProductResponse")]
        Sito.ServiceReference2.ValueTupleOfintstring addProduct(Sito.ServiceReference2.Product product);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/addProduct", ReplyAction="http://tempuri.org/IECommerce/addProductResponse")]
        System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfintstring> addProductAsync(Sito.ServiceReference2.Product product);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/viewSales", ReplyAction="http://tempuri.org/IECommerce/viewSalesResponse")]
        Sito.ServiceReference2.Sale[] viewSales(Sito.ServiceReference2.User user);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/viewSales", ReplyAction="http://tempuri.org/IECommerce/viewSalesResponse")]
        System.Threading.Tasks.Task<Sito.ServiceReference2.Sale[]> viewSalesAsync(Sito.ServiceReference2.User user);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/viewUsers", ReplyAction="http://tempuri.org/IECommerce/viewUsersResponse")]
        Sito.ServiceReference2.User[] viewUsers(Sito.ServiceReference2.User user);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IECommerce/viewUsers", ReplyAction="http://tempuri.org/IECommerce/viewUsersResponse")]
        System.Threading.Tasks.Task<Sito.ServiceReference2.User[]> viewUsersAsync(Sito.ServiceReference2.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IECommerceChannel : Sito.ServiceReference2.IECommerce, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ECommerceClient : System.ServiceModel.ClientBase<Sito.ServiceReference2.IECommerce>, Sito.ServiceReference2.IECommerce {
        
        public ECommerceClient() {
        }
        
        public ECommerceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ECommerceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECommerceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECommerceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu register(string username, string email, string password) {
            return base.Channel.register(username, email, password);
        }
        
        public System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu> registerAsync(string username, string email, string password) {
            return base.Channel.registerAsync(username, email, password);
        }
        
        public Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu login(string email, string password) {
            return base.Channel.login(email, password);
        }
        
        public System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfUserstringdlgy1VAu> loginAsync(string email, string password) {
            return base.Channel.loginAsync(email, password);
        }
        
        public Sito.ServiceReference2.ValueTupleOfArrayOfProductstringdlgy1VAu viewProducts(bool admin, int offset) {
            return base.Channel.viewProducts(admin, offset);
        }
        
        public System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfArrayOfProductstringdlgy1VAu> viewProductsAsync(bool admin, int offset) {
            return base.Channel.viewProductsAsync(admin, offset);
        }
        
        public Sito.ServiceReference2.ValueTupleOfintstring addProduct(Sito.ServiceReference2.Product product) {
            return base.Channel.addProduct(product);
        }
        
        public System.Threading.Tasks.Task<Sito.ServiceReference2.ValueTupleOfintstring> addProductAsync(Sito.ServiceReference2.Product product) {
            return base.Channel.addProductAsync(product);
        }
        
        public Sito.ServiceReference2.Sale[] viewSales(Sito.ServiceReference2.User user) {
            return base.Channel.viewSales(user);
        }
        
        public System.Threading.Tasks.Task<Sito.ServiceReference2.Sale[]> viewSalesAsync(Sito.ServiceReference2.User user) {
            return base.Channel.viewSalesAsync(user);
        }
        
        public Sito.ServiceReference2.User[] viewUsers(Sito.ServiceReference2.User user) {
            return base.Channel.viewUsers(user);
        }
        
        public System.Threading.Tasks.Task<Sito.ServiceReference2.User[]> viewUsersAsync(Sito.ServiceReference2.User user) {
            return base.Channel.viewUsersAsync(user);
        }
    }
}
