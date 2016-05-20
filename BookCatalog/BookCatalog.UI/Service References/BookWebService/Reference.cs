﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookCatalog.UI.BookWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bookcatalogwebservice.org/", ConfigurationName="BookWebService.BookWebServiceSoap")]
    public interface BookWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetBooksCount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int GetBooksCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetBooksCount", ReplyAction="*")]
        System.Threading.Tasks.Task<int> GetBooksCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetAllBooks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        BookCatalog.UI.BookWebService.BookViewModel[] GetAllBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetAllBooks", ReplyAction="*")]
        System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.BookViewModel[]> GetAllBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetBooks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        BookCatalog.UI.BookWebService.GetBooksResponse GetBooks(BookCatalog.UI.BookWebService.GetBooksRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetBooks", ReplyAction="*")]
        System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.GetBooksResponse> GetBooksAsync(BookCatalog.UI.BookWebService.GetBooksRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/BookExists", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        bool BookExists(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/BookExists", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> BookExistsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetBook", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        BookCatalog.UI.BookWebService.BookViewModel GetBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetBook", ReplyAction="*")]
        System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.BookViewModel> GetBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/Manage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        int Manage(BookCatalog.UI.BookWebService.BookViewModel bookVM);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/Manage", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ManageAsync(BookCatalog.UI.BookWebService.BookViewModel bookVM);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        void Delete(int bookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/Delete", ReplyAction="*")]
        System.Threading.Tasks.Task DeleteAsync(int bookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetAuthors", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        string GetAuthors(int bookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetAuthors", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetAuthorsAsync(int bookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/PopulateMultiSelectList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        BookCatalog.UI.BookWebService.SelectListItem[] PopulateMultiSelectList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/PopulateMultiSelectList", ReplyAction="*")]
        System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.SelectListItem[]> PopulateMultiSelectListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MemberInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CustomFilter[]))]
        System.Xml.XmlNode GetXML();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bookcatalogwebservice.org/GetXML", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetXMLAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class BookViewModel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string nameField;
        
        private System.DateTime publishedDateField;
        
        private int pagesCountField;
        
        private string descriptionField;
        
        private int ratingField;
        
        private AuthorViewModel[] authorsField;
        
        private int[] authorsIdsField;
        
        private SelectListItem[] authorsOptionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.DateTime PublishedDate {
            get {
                return this.publishedDateField;
            }
            set {
                this.publishedDateField = value;
                this.RaisePropertyChanged("PublishedDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int PagesCount {
            get {
                return this.pagesCountField;
            }
            set {
                this.pagesCountField = value;
                this.RaisePropertyChanged("PagesCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int Rating {
            get {
                return this.ratingField;
            }
            set {
                this.ratingField = value;
                this.RaisePropertyChanged("Rating");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=6)]
        public AuthorViewModel[] Authors {
            get {
                return this.authorsField;
            }
            set {
                this.authorsField = value;
                this.RaisePropertyChanged("Authors");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=7)]
        public int[] AuthorsIds {
            get {
                return this.authorsIdsField;
            }
            set {
                this.authorsIdsField = value;
                this.RaisePropertyChanged("AuthorsIds");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=8)]
        public SelectListItem[] AuthorsOptions {
            get {
                return this.authorsOptionsField;
            }
            set {
                this.authorsOptionsField = value;
                this.RaisePropertyChanged("AuthorsOptions");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class AuthorViewModel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string firstNameField;
        
        private string secondNameField;
        
        private int booksCountField;
        
        private ShortBookViewModel[] booksField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
                this.RaisePropertyChanged("FirstName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SecondName {
            get {
                return this.secondNameField;
            }
            set {
                this.secondNameField = value;
                this.RaisePropertyChanged("SecondName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int BooksCount {
            get {
                return this.booksCountField;
            }
            set {
                this.booksCountField = value;
                this.RaisePropertyChanged("BooksCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        public ShortBookViewModel[] Books {
            get {
                return this.booksField;
            }
            set {
                this.booksField = value;
                this.RaisePropertyChanged("Books");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class ShortBookViewModel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private int yearField;
        
        private int ratingField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
                this.RaisePropertyChanged("Year");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Rating {
            get {
                return this.ratingField;
            }
            set {
                this.ratingField = value;
                this.RaisePropertyChanged("Rating");
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Type))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public abstract partial class MemberInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public abstract partial class Type : MemberInfo {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class CustomFilter : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object valueField;
        
        private Type memberTypeField;
        
        private string memberField;
        
        private CustomOperator operatorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public object Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Type MemberType {
            get {
                return this.memberTypeField;
            }
            set {
                this.memberTypeField = value;
                this.RaisePropertyChanged("MemberType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Member {
            get {
                return this.memberField;
            }
            set {
                this.memberField = value;
                this.RaisePropertyChanged("Member");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public CustomOperator Operator {
            get {
                return this.operatorField;
            }
            set {
                this.operatorField = value;
                this.RaisePropertyChanged("Operator");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public enum CustomOperator {
        
        /// <remarks/>
        Contains,
        
        /// <remarks/>
        Greater,
        
        /// <remarks/>
        Less,
        
        /// <remarks/>
        GreaterOrEqual,
        
        /// <remarks/>
        LessOrEqual,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class Sort : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string fieldNameField;
        
        private ListSortDirection sortDirectionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string FieldName {
            get {
                return this.fieldNameField;
            }
            set {
                this.fieldNameField = value;
                this.RaisePropertyChanged("FieldName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public ListSortDirection SortDirection {
            get {
                return this.sortDirectionField;
            }
            set {
                this.sortDirectionField = value;
                this.RaisePropertyChanged("SortDirection");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public enum ListSortDirection {
        
        /// <remarks/>
        Ascending,
        
        /// <remarks/>
        Descending,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class SelectListGroup : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool disabledField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Disabled {
            get {
                return this.disabledField;
            }
            set {
                this.disabledField = value;
                this.RaisePropertyChanged("Disabled");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bookcatalogwebservice.org/")]
    public partial class SelectListItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool disabledField;
        
        private SelectListGroup groupField;
        
        private bool selectedField;
        
        private string textField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Disabled {
            get {
                return this.disabledField;
            }
            set {
                this.disabledField = value;
                this.RaisePropertyChanged("Disabled");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public SelectListGroup Group {
            get {
                return this.groupField;
            }
            set {
                this.groupField = value;
                this.RaisePropertyChanged("Group");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool Selected {
            get {
                return this.selectedField;
            }
            set {
                this.selectedField = value;
                this.RaisePropertyChanged("Selected");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
                this.RaisePropertyChanged("Text");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetBooks", WrapperNamespace="http://bookcatalogwebservice.org/", IsWrapped=true)]
    public partial class GetBooksRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bookcatalogwebservice.org/", Order=0)]
        public BookCatalog.UI.BookWebService.Sort[] sorts;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bookcatalogwebservice.org/", Order=1)]
        public BookCatalog.UI.BookWebService.CustomFilter[] filters;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bookcatalogwebservice.org/", Order=2)]
        public int take;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bookcatalogwebservice.org/", Order=3)]
        public int skip;
        
        public GetBooksRequest() {
        }
        
        public GetBooksRequest(BookCatalog.UI.BookWebService.Sort[] sorts, BookCatalog.UI.BookWebService.CustomFilter[] filters, int take, int skip) {
            this.sorts = sorts;
            this.filters = filters;
            this.take = take;
            this.skip = skip;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetBooksResponse", WrapperNamespace="http://bookcatalogwebservice.org/", IsWrapped=true)]
    public partial class GetBooksResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bookcatalogwebservice.org/", Order=0)]
        public BookCatalog.UI.BookWebService.BookViewModel[] GetBooksResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bookcatalogwebservice.org/", Order=1)]
        public int total;
        
        public GetBooksResponse() {
        }
        
        public GetBooksResponse(BookCatalog.UI.BookWebService.BookViewModel[] GetBooksResult, int total) {
            this.GetBooksResult = GetBooksResult;
            this.total = total;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BookWebServiceSoapChannel : BookCatalog.UI.BookWebService.BookWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookWebServiceSoapClient : System.ServiceModel.ClientBase<BookCatalog.UI.BookWebService.BookWebServiceSoap>, BookCatalog.UI.BookWebService.BookWebServiceSoap {
        
        public BookWebServiceSoapClient() {
        }
        
        public BookWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetBooksCount() {
            return base.Channel.GetBooksCount();
        }
        
        public System.Threading.Tasks.Task<int> GetBooksCountAsync() {
            return base.Channel.GetBooksCountAsync();
        }
        
        public BookCatalog.UI.BookWebService.BookViewModel[] GetAllBooks() {
            return base.Channel.GetAllBooks();
        }
        
        public System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.BookViewModel[]> GetAllBooksAsync() {
            return base.Channel.GetAllBooksAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BookCatalog.UI.BookWebService.GetBooksResponse BookCatalog.UI.BookWebService.BookWebServiceSoap.GetBooks(BookCatalog.UI.BookWebService.GetBooksRequest request) {
            return base.Channel.GetBooks(request);
        }
        
        public BookCatalog.UI.BookWebService.BookViewModel[] GetBooks(BookCatalog.UI.BookWebService.Sort[] sorts, BookCatalog.UI.BookWebService.CustomFilter[] filters, int take, int skip, out int total) {
            BookCatalog.UI.BookWebService.GetBooksRequest inValue = new BookCatalog.UI.BookWebService.GetBooksRequest();
            inValue.sorts = sorts;
            inValue.filters = filters;
            inValue.take = take;
            inValue.skip = skip;
            BookCatalog.UI.BookWebService.GetBooksResponse retVal = ((BookCatalog.UI.BookWebService.BookWebServiceSoap)(this)).GetBooks(inValue);
            total = retVal.total;
            return retVal.GetBooksResult;
        }
        
        public System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.GetBooksResponse> GetBooksAsync(BookCatalog.UI.BookWebService.GetBooksRequest request) {
            return base.Channel.GetBooksAsync(request);
        }
        
        public bool BookExists(int id) {
            return base.Channel.BookExists(id);
        }
        
        public System.Threading.Tasks.Task<bool> BookExistsAsync(int id) {
            return base.Channel.BookExistsAsync(id);
        }
        
        public BookCatalog.UI.BookWebService.BookViewModel GetBook(int id) {
            return base.Channel.GetBook(id);
        }
        
        public System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.BookViewModel> GetBookAsync(int id) {
            return base.Channel.GetBookAsync(id);
        }
        
        public int Manage(BookCatalog.UI.BookWebService.BookViewModel bookVM) {
            return base.Channel.Manage(bookVM);
        }
        
        public System.Threading.Tasks.Task<int> ManageAsync(BookCatalog.UI.BookWebService.BookViewModel bookVM) {
            return base.Channel.ManageAsync(bookVM);
        }
        
        public void Delete(int bookId) {
            base.Channel.Delete(bookId);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int bookId) {
            return base.Channel.DeleteAsync(bookId);
        }
        
        public string GetAuthors(int bookId) {
            return base.Channel.GetAuthors(bookId);
        }
        
        public System.Threading.Tasks.Task<string> GetAuthorsAsync(int bookId) {
            return base.Channel.GetAuthorsAsync(bookId);
        }
        
        public BookCatalog.UI.BookWebService.SelectListItem[] PopulateMultiSelectList() {
            return base.Channel.PopulateMultiSelectList();
        }
        
        public System.Threading.Tasks.Task<BookCatalog.UI.BookWebService.SelectListItem[]> PopulateMultiSelectListAsync() {
            return base.Channel.PopulateMultiSelectListAsync();
        }
        
        public System.Xml.XmlNode GetXML() {
            return base.Channel.GetXML();
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetXMLAsync() {
            return base.Channel.GetXMLAsync();
        }
    }
}