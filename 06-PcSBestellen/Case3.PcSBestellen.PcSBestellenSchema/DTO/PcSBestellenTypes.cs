﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcsbestellen:v1:messages", ClrNamespace="Case3.PcSBestellen.V1.Messages")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcsbestellen:v1:schema", ClrNamespace="Case3.PcSBestellen.V1.Schema")]

namespace Case3.PcSBestellen.V1.Messages
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindNextBestellingRequestMessage", Namespace="urn:case3-pcsbestellen:v1:messages")]
    public partial class FindNextBestellingRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindNextBestellingResultMessage", Namespace="urn:case3-pcsbestellen:v1:messages")]
    public partial class FindNextBestellingResultMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSBestellen.V1.Schema.BestellingPcS BestellingOpdrachtField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.PcSBestellen.V1.Schema.BestellingPcS BestellingOpdracht
        {
            get
            {
                return this.BestellingOpdrachtField;
            }
            set
            {
                this.BestellingOpdrachtField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BestellingPlaatsenRequestMessage", Namespace="urn:case3-pcsbestellen:v1:messages")]
    public partial class BestellingPlaatsenRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSBestellen.V1.Schema.BestellingPcS BestellingPcSField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.PcSBestellen.V1.Schema.BestellingPcS BestellingPcS
        {
            get
            {
                return this.BestellingPcSField;
            }
            set
            {
                this.BestellingPcSField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BestellingPlaatsenResultMessage", Namespace="urn:case3-pcsbestellen:v1:messages")]
    public partial class BestellingPlaatsenResultMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateBestellingStatusRequestMessage", Namespace="urn:case3-pcsbestellen:v1:messages")]
    public partial class UpdateBestellingStatusRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSBestellen.V1.Schema.BestellingPcS BestellingField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.PcSBestellen.V1.Schema.BestellingPcS Bestelling
        {
            get
            {
                return this.BestellingField;
            }
            set
            {
                this.BestellingField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateBestellingStatusResultMessage", Namespace="urn:case3-pcsbestellen:v1:messages")]
    public partial class UpdateBestellingStatusResultMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
    }
}
namespace Case3.PcSBestellen.V1.Schema
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BestellingPcS", Namespace="urn:case3-pcsbestellen:v1:schema")]
    public partial class BestellingPcS : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> BestellingIDField;
        
        private System.Nullable<int> FactuurIDField;
        
        private string FactuurDatumField;
        
        private System.Nullable<int> StatusField;
        
        private Case3.PcSBestellen.V1.Schema.KlantgegevensPcS KlantgegevensField;
        
        private Case3.PcSBestellen.V1.Schema.ArtikelenPcS ArtikelenPcSField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> BestellingID
        {
            get
            {
                return this.BestellingIDField;
            }
            set
            {
                this.BestellingIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> FactuurID
        {
            get
            {
                return this.FactuurIDField;
            }
            set
            {
                this.FactuurIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string FactuurDatum
        {
            get
            {
                return this.FactuurDatumField;
            }
            set
            {
                this.FactuurDatumField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.Nullable<int> Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public Case3.PcSBestellen.V1.Schema.KlantgegevensPcS Klantgegevens
        {
            get
            {
                return this.KlantgegevensField;
            }
            set
            {
                this.KlantgegevensField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public Case3.PcSBestellen.V1.Schema.ArtikelenPcS ArtikelenPcS
        {
            get
            {
                return this.ArtikelenPcSField;
            }
            set
            {
                this.ArtikelenPcSField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KlantgegevensPcS", Namespace="urn:case3-pcsbestellen:v1:schema")]
    public partial class KlantgegevensPcS : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NaamField;
        
        private string Adresregel1Field;
        
        private string Adresregel2Field;
        
        private string PostcodeField;
        
        private string WoonplaatsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Naam
        {
            get
            {
                return this.NaamField;
            }
            set
            {
                this.NaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string Adresregel1
        {
            get
            {
                return this.Adresregel1Field;
            }
            set
            {
                this.Adresregel1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string Adresregel2
        {
            get
            {
                return this.Adresregel2Field;
            }
            set
            {
                this.Adresregel2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public string Postcode
        {
            get
            {
                return this.PostcodeField;
            }
            set
            {
                this.PostcodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public string Woonplaats
        {
            get
            {
                return this.WoonplaatsField;
            }
            set
            {
                this.WoonplaatsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArtikelenPcS", Namespace="urn:case3-pcsbestellen:v1:schema", ItemName="ArtikelItemPcS")]
    public class ArtikelenPcS : System.Collections.Generic.List<Case3.PcSBestellen.V1.Schema.BestelItemPcS>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BestelItemPcS", Namespace="urn:case3-pcsbestellen:v1:schema")]
    public partial class BestelItemPcS : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSCatalogusBeheer.Schema.ProductNS.Product ProductField;
        
        private int AantalField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.BSCatalogusBeheer.Schema.ProductNS.Product Product
        {
            get
            {
                return this.ProductField;
            }
            set
            {
                this.ProductField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int Aantal
        {
            get
            {
                return this.AantalField;
            }
            set
            {
                this.AantalField = value;
            }
        }
    }
}
