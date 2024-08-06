using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models 
{
	public class ServiceTypeItem : ServiceTypeDetails
	{
		public ServiceTypeItem()
		{

			Materials = new List<Material>();
		}
		public int ServiceTypeID { get; set; }
		public int JobTypeID { get; set; }
		public string JobTypeName { get; set; }
		public string Comment { get; set; }
		public int LaborStatus { get; set; }
		public int RowOrder { get; set; }
		public string RandomID { get; set; }
		public int? QuoteID { get; set; }
		public bool ShowLaborUnitCost { get; set; }
		public bool ShowTotalLaborCost { get; set; }
		public string ScheduleNotes { get; set; }
		public string ServiceNotes { get; set; }
		public decimal TotalSQ { get; set; }
		public decimal TotalMargin { get; set; }
		public int ImportedServiceTypeID { get; set; }
		public string ServiceLinkTypeID { get; set; }
		public bool ShowAllMaterials { get; set; }
		public int CreatedBy { get; set; }
		public List<Material> Materials { get; set; }
		public int Action { get; set; } = (int)ActionEnum.None;
		public int? ContractorID { get; set; }
		public bool? ContractorReadyForPayment { get; set; }
		public int? TemplateID { get; set; }

		/// <summary>
		/// This property tracks the property in which a change is made corresponding to a service type
		/// </summary>
		public ServiceTypeActionEnum? ServiceTypeAction { get; set; }
		public object NewValue { get; set; }
		public int TemplateServiceTypeID { get; set; }
	}
}
