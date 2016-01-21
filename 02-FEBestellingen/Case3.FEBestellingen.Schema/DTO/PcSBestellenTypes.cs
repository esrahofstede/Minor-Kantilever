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
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcsbestellen:v1:schema", ClrNamespace="case3pcsbestellen.v1.schema")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:schemas-www-kantilever-nl:bscatalogusbeheer:product:v1", ClrNamespace="Case3.BSCatalogusBeheer.Schema.ProductNSPcS")]

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
        
        private case3pcsbestellen.v1.schema.BestellingPcS BestellingOpdrachtField;
        
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
        public case3pcsbestellen.v1.schema.BestellingPcS BestellingOpdracht
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
        
        private case3pcsbestellen.v1.schema.BestellingPcS BestellingPcSField;
        
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
        public case3pcsbestellen.v1.schema.BestellingPcS BestellingPcS
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
        
        private long BestellingIDField;
        
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
        public long BestellingID
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
namespace case3pcsbestellen.v1.schema
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
        
        private System.Nullable<int> BTWPercentageField;
        
        private case3pcsbestellen.v1.schema.KlantgegevensPcS KlantgegevensField;
        
        private case3pcsbestellen.v1.schema.ArtikelenPcS ArtikelenPcSField;
        
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
        public System.Nullable<int> BTWPercentage
        {
            get
            {
                return this.BTWPercentageField;
            }
            set
            {
                this.BTWPercentageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public case3pcsbestellen.v1.schema.KlantgegevensPcS Klantgegevens
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=5)]
        public case3pcsbestellen.v1.schema.ArtikelenPcS ArtikelenPcS
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
        
        private string TelefoonnummerField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public string Telefoonnummer
        {
            get
            {
                return this.TelefoonnummerField;
            }
            set
            {
                this.TelefoonnummerField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArtikelenPcS", Namespace="urn:case3-pcsbestellen:v1:schema", ItemName="ArtikelItemPcS")]
    public class ArtikelenPcS : System.Collections.Generic.List<case3pcsbestellen.v1.schema.BestelItemPcS>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BestelItemPcS", Namespace="urn:case3-pcsbestellen:v1:schema")]
    public partial class BestelItemPcS : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSCatalogusBeheer.Schema.ProductNSPcS.Product ProductField;
        
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
        public Case3.BSCatalogusBeheer.Schema.ProductNSPcS.Product Product
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
namespace Case3.BSCatalogusBeheer.Schema.ProductNSPcS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="urn:schemas-www-kantilever-nl:bscatalogusbeheer:product:v1")]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> IdField;
        
        private string AfbeeldingURLField;
        
        private string BeschrijvingField;
        
        private string LeverancierNaamField;
        
        private string LeveranciersProductIdField;
        
        private System.Nullable<System.DateTime> LeverbaarTotField;
        
        private System.Nullable<System.DateTime> LeverbaarVanafField;
        
        private string NaamField;
        
        private System.Nullable<decimal> PrijsField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string AfbeeldingURL
        {
            get
            {
                return this.AfbeeldingURLField;
            }
            set
            {
                this.AfbeeldingURLField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Beschrijving
        {
            get
            {
                return this.BeschrijvingField;
            }
            set
            {
                this.BeschrijvingField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=3)]
        public string LeverancierNaam
        {
            get
            {
                return this.LeverancierNaamField;
            }
            set
            {
                this.LeverancierNaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=4)]
        public string LeveranciersProductId
        {
            get
            {
                return this.LeveranciersProductIdField;
            }
            set
            {
                this.LeveranciersProductIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public System.Nullable<System.DateTime> LeverbaarTot
        {
            get
            {
                return this.LeverbaarTotField;
            }
            set
            {
                this.LeverbaarTotField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public System.Nullable<System.DateTime> LeverbaarVanaf
        {
            get
            {
                return this.LeverbaarVanafField;
            }
            set
            {
                this.LeverbaarVanafField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public System.Nullable<decimal> Prijs
        {
            get
            {
                return this.PrijsField;
            }
            set
            {
                this.PrijsField = value;
            }
        }
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="Case3.GoudGeel.PcSBestellen", ConfigurationName="IPcSBestellenService")]
public interface IPcSBestellenService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/FindNextBestelling", ReplyAction="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/FindNextBestellingResponse")]
    Case3.PcSBestellen.V1.Messages.FindNextBestellingResultMessage FindNextBestelling(Case3.PcSBestellen.V1.Messages.FindNextBestellingRequestMessage requestMessage);
    
    [System.ServiceModel.OperationContractAttribute(Action="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/FindNextBestelling", ReplyAction="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/FindNextBestellingResponse")]
    System.Threading.Tasks.Task<Case3.PcSBestellen.V1.Messages.FindNextBestellingResultMessage> FindNextBestellingAsync(Case3.PcSBestellen.V1.Messages.FindNextBestellingRequestMessage requestMessage);
    
    [System.ServiceModel.OperationContractAttribute(Action="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/BestellingPlaatsen", ReplyAction="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/BestellingPlaatsenResponse")]
    Case3.PcSBestellen.V1.Messages.BestellingPlaatsenResultMessage BestellingPlaatsen(Case3.PcSBestellen.V1.Messages.BestellingPlaatsenRequestMessage bestelling);
    
    [System.ServiceModel.OperationContractAttribute(Action="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/BestellingPlaatsen", ReplyAction="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/BestellingPlaatsenResponse")]
    System.Threading.Tasks.Task<Case3.PcSBestellen.V1.Messages.BestellingPlaatsenResultMessage> BestellingPlaatsenAsync(Case3.PcSBestellen.V1.Messages.BestellingPlaatsenRequestMessage bestelling);
    
    [System.ServiceModel.OperationContractAttribute(Action="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/UpdateBestelling", ReplyAction="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/UpdateBestellingResponse")]
    Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusResultMessage UpdateBestelling(Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusRequestMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/UpdateBestelling", ReplyAction="Case3.GoudGeel.PcSBestellen/IPcSBestellenService/UpdateBestellingResponse")]
    System.Threading.Tasks.Task<Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusResultMessage> UpdateBestellingAsync(Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusRequestMessage request);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IPcSBestellenServiceChannel : IPcSBestellenService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class PcSBestellenServiceClient : System.ServiceModel.ClientBase<IPcSBestellenService>, IPcSBestellenService
{
    
    public PcSBestellenServiceClient()
    {
    }
    
    public PcSBestellenServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public PcSBestellenServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PcSBestellenServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PcSBestellenServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public Case3.PcSBestellen.V1.Messages.FindNextBestellingResultMessage FindNextBestelling(Case3.PcSBestellen.V1.Messages.FindNextBestellingRequestMessage requestMessage)
    {
        return base.Channel.FindNextBestelling(requestMessage);
    }
    
    public System.Threading.Tasks.Task<Case3.PcSBestellen.V1.Messages.FindNextBestellingResultMessage> FindNextBestellingAsync(Case3.PcSBestellen.V1.Messages.FindNextBestellingRequestMessage requestMessage)
    {
        return base.Channel.FindNextBestellingAsync(requestMessage);
    }
    
    public Case3.PcSBestellen.V1.Messages.BestellingPlaatsenResultMessage BestellingPlaatsen(Case3.PcSBestellen.V1.Messages.BestellingPlaatsenRequestMessage bestelling)
    {
        return base.Channel.BestellingPlaatsen(bestelling);
    }
    
    public System.Threading.Tasks.Task<Case3.PcSBestellen.V1.Messages.BestellingPlaatsenResultMessage> BestellingPlaatsenAsync(Case3.PcSBestellen.V1.Messages.BestellingPlaatsenRequestMessage bestelling)
    {
        return base.Channel.BestellingPlaatsenAsync(bestelling);
    }
    
    public Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusResultMessage UpdateBestelling(Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusRequestMessage request)
    {
        return base.Channel.UpdateBestelling(request);
    }
    
    public System.Threading.Tasks.Task<Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusResultMessage> UpdateBestellingAsync(Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusRequestMessage request)
    {
        return base.Channel.UpdateBestellingAsync(request);
    }
}
