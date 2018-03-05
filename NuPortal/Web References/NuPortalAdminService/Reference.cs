﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace NuPortal.NuPortalAdminService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NuPortalAdminServiceSoap", Namespace="http://tempuri.org/")]
    public partial class NuPortalAdminService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SaveNewRequestTypesOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetGroupMembersOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetDeptGroupsOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateDeptsOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateGroupsOperationCompleted;
        
        private System.Threading.SendOrPostCallback CustomizationByAdminOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NuPortalAdminService() {
            this.Url = global::NuPortal.Properties.Settings.Default.NuPortal_NuPortalAdminService_NuPortalAdminService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SaveNewRequestTypesCompletedEventHandler SaveNewRequestTypesCompleted;
        
        /// <remarks/>
        public event SetGroupMembersCompletedEventHandler SetGroupMembersCompleted;
        
        /// <remarks/>
        public event SetDeptGroupsCompletedEventHandler SetDeptGroupsCompleted;
        
        /// <remarks/>
        public event UpdateDeptsCompletedEventHandler UpdateDeptsCompleted;
        
        /// <remarks/>
        public event UpdateGroupsCompletedEventHandler UpdateGroupsCompleted;
        
        /// <remarks/>
        public event CustomizationByAdminCompletedEventHandler CustomizationByAdminCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveNewRequestTypes", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SaveNewRequestTypes(int Id, string categoryName, string categoryType, int CategoryTypeId, int CompanyId, int GroupId, int CreatedEmpID, int ModifiedEmpID, int Status, int Operation) {
            object[] results = this.Invoke("SaveNewRequestTypes", new object[] {
                        Id,
                        categoryName,
                        categoryType,
                        CategoryTypeId,
                        CompanyId,
                        GroupId,
                        CreatedEmpID,
                        ModifiedEmpID,
                        Status,
                        Operation});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SaveNewRequestTypesAsync(int Id, string categoryName, string categoryType, int CategoryTypeId, int CompanyId, int GroupId, int CreatedEmpID, int ModifiedEmpID, int Status, int Operation) {
            this.SaveNewRequestTypesAsync(Id, categoryName, categoryType, CategoryTypeId, CompanyId, GroupId, CreatedEmpID, ModifiedEmpID, Status, Operation, null);
        }
        
        /// <remarks/>
        public void SaveNewRequestTypesAsync(int Id, string categoryName, string categoryType, int CategoryTypeId, int CompanyId, int GroupId, int CreatedEmpID, int ModifiedEmpID, int Status, int Operation, object userState) {
            if ((this.SaveNewRequestTypesOperationCompleted == null)) {
                this.SaveNewRequestTypesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveNewRequestTypesOperationCompleted);
            }
            this.InvokeAsync("SaveNewRequestTypes", new object[] {
                        Id,
                        categoryName,
                        categoryType,
                        CategoryTypeId,
                        CompanyId,
                        GroupId,
                        CreatedEmpID,
                        ModifiedEmpID,
                        Status,
                        Operation}, this.SaveNewRequestTypesOperationCompleted, userState);
        }
        
        private void OnSaveNewRequestTypesOperationCompleted(object arg) {
            if ((this.SaveNewRequestTypesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveNewRequestTypesCompleted(this, new SaveNewRequestTypesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetGroupMembers", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SetGroupMembers(int ResourceId, int EmpId, string jsonGroupDetails) {
            object[] results = this.Invoke("SetGroupMembers", new object[] {
                        ResourceId,
                        EmpId,
                        jsonGroupDetails});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SetGroupMembersAsync(int ResourceId, int EmpId, string jsonGroupDetails) {
            this.SetGroupMembersAsync(ResourceId, EmpId, jsonGroupDetails, null);
        }
        
        /// <remarks/>
        public void SetGroupMembersAsync(int ResourceId, int EmpId, string jsonGroupDetails, object userState) {
            if ((this.SetGroupMembersOperationCompleted == null)) {
                this.SetGroupMembersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetGroupMembersOperationCompleted);
            }
            this.InvokeAsync("SetGroupMembers", new object[] {
                        ResourceId,
                        EmpId,
                        jsonGroupDetails}, this.SetGroupMembersOperationCompleted, userState);
        }
        
        private void OnSetGroupMembersOperationCompleted(object arg) {
            if ((this.SetGroupMembersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetGroupMembersCompleted(this, new SetGroupMembersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetDeptGroups", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SetDeptGroups(string Name, int CompanyId, int DeptId, int Status, int Operation) {
            object[] results = this.Invoke("SetDeptGroups", new object[] {
                        Name,
                        CompanyId,
                        DeptId,
                        Status,
                        Operation});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetDeptGroupsAsync(string Name, int CompanyId, int DeptId, int Status, int Operation) {
            this.SetDeptGroupsAsync(Name, CompanyId, DeptId, Status, Operation, null);
        }
        
        /// <remarks/>
        public void SetDeptGroupsAsync(string Name, int CompanyId, int DeptId, int Status, int Operation, object userState) {
            if ((this.SetDeptGroupsOperationCompleted == null)) {
                this.SetDeptGroupsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetDeptGroupsOperationCompleted);
            }
            this.InvokeAsync("SetDeptGroups", new object[] {
                        Name,
                        CompanyId,
                        DeptId,
                        Status,
                        Operation}, this.SetDeptGroupsOperationCompleted, userState);
        }
        
        private void OnSetDeptGroupsOperationCompleted(object arg) {
            if ((this.SetDeptGroupsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetDeptGroupsCompleted(this, new SetDeptGroupsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateDepts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UpdateDepts(int CompanyId, int EmpId, string jsonDeptDetails) {
            object[] results = this.Invoke("UpdateDepts", new object[] {
                        CompanyId,
                        EmpId,
                        jsonDeptDetails});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateDeptsAsync(int CompanyId, int EmpId, string jsonDeptDetails) {
            this.UpdateDeptsAsync(CompanyId, EmpId, jsonDeptDetails, null);
        }
        
        /// <remarks/>
        public void UpdateDeptsAsync(int CompanyId, int EmpId, string jsonDeptDetails, object userState) {
            if ((this.UpdateDeptsOperationCompleted == null)) {
                this.UpdateDeptsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateDeptsOperationCompleted);
            }
            this.InvokeAsync("UpdateDepts", new object[] {
                        CompanyId,
                        EmpId,
                        jsonDeptDetails}, this.UpdateDeptsOperationCompleted, userState);
        }
        
        private void OnUpdateDeptsOperationCompleted(object arg) {
            if ((this.UpdateDeptsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateDeptsCompleted(this, new UpdateDeptsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateGroups", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UpdateGroups(int CompanyId, int EmpId, string jsonGroupDetails) {
            object[] results = this.Invoke("UpdateGroups", new object[] {
                        CompanyId,
                        EmpId,
                        jsonGroupDetails});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateGroupsAsync(int CompanyId, int EmpId, string jsonGroupDetails) {
            this.UpdateGroupsAsync(CompanyId, EmpId, jsonGroupDetails, null);
        }
        
        /// <remarks/>
        public void UpdateGroupsAsync(int CompanyId, int EmpId, string jsonGroupDetails, object userState) {
            if ((this.UpdateGroupsOperationCompleted == null)) {
                this.UpdateGroupsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateGroupsOperationCompleted);
            }
            this.InvokeAsync("UpdateGroups", new object[] {
                        CompanyId,
                        EmpId,
                        jsonGroupDetails}, this.UpdateGroupsOperationCompleted, userState);
        }
        
        private void OnUpdateGroupsOperationCompleted(object arg) {
            if ((this.UpdateGroupsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateGroupsCompleted(this, new UpdateGroupsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CustomizationByAdmin", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CustomizationByAdmin(string JsonData, int CompanyId, int Status, int EmpId, int CategoryTypeId, int Operation) {
            object[] results = this.Invoke("CustomizationByAdmin", new object[] {
                        JsonData,
                        CompanyId,
                        Status,
                        EmpId,
                        CategoryTypeId,
                        Operation});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CustomizationByAdminAsync(string JsonData, int CompanyId, int Status, int EmpId, int CategoryTypeId, int Operation) {
            this.CustomizationByAdminAsync(JsonData, CompanyId, Status, EmpId, CategoryTypeId, Operation, null);
        }
        
        /// <remarks/>
        public void CustomizationByAdminAsync(string JsonData, int CompanyId, int Status, int EmpId, int CategoryTypeId, int Operation, object userState) {
            if ((this.CustomizationByAdminOperationCompleted == null)) {
                this.CustomizationByAdminOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCustomizationByAdminOperationCompleted);
            }
            this.InvokeAsync("CustomizationByAdmin", new object[] {
                        JsonData,
                        CompanyId,
                        Status,
                        EmpId,
                        CategoryTypeId,
                        Operation}, this.CustomizationByAdminOperationCompleted, userState);
        }
        
        private void OnCustomizationByAdminOperationCompleted(object arg) {
            if ((this.CustomizationByAdminCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CustomizationByAdminCompleted(this, new CustomizationByAdminCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void SaveNewRequestTypesCompletedEventHandler(object sender, SaveNewRequestTypesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveNewRequestTypesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveNewRequestTypesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void SetGroupMembersCompletedEventHandler(object sender, SetGroupMembersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetGroupMembersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetGroupMembersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void SetDeptGroupsCompletedEventHandler(object sender, SetDeptGroupsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetDeptGroupsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetDeptGroupsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void UpdateDeptsCompletedEventHandler(object sender, UpdateDeptsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateDeptsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateDeptsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void UpdateGroupsCompletedEventHandler(object sender, UpdateGroupsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateGroupsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateGroupsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void CustomizationByAdminCompletedEventHandler(object sender, CustomizationByAdminCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CustomizationByAdminCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CustomizationByAdminCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591