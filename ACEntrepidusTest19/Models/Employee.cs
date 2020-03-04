﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEntrepidusTest19.Consts;

namespace ACEntrepidusTest19.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //TODO Los mensajes podrían venir de un Resource para lograr el multilenguaje, pero para acelerar el desarrollo por ahora solo para este test, lo dejamos acá hardcoded

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "Por favor introduzca la {0}")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(RegExConsts.CedulaRegEx, ErrorMessage = "Introduzca una Cédula válida")]
        public string DocumentId { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "Por favor introduzca el {0}")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(RegExConsts.NameRegEx, ErrorMessage = "Introduzca un Nombre válido")]
        public string FullName { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Por favor introduzca la {0}")]
        [StringLength(1024, ErrorMessage = "El campo {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(RegExConsts.NameRegEx, ErrorMessage = "Introduzca una Dirección Válida")]
        public string Address { get; set; }

        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "Por favor introduzca un Correo Electrónico válido")]
        public string EMail { get; set; }

        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "No es un número de Teléfono válido")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Fecha de Contrato", Prompt = "dd/mm/yyyy")]
        [Required(ErrorMessage = "Por favor seleccione la {0}")]
        [DataType(DataType.Text)] 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Remote("NotAfterToday", "Employees", ErrorMessage = "La {0} no puede ser posterior al día de hoy.")]
        //[NotAfterToday(ErrorMessage = "La {0} no puede ser posterior al día de hoy.")]
        //[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
        public DateTime ContractDate { get; set; }

        [Display(Name = "Fecha de Contrato", Prompt = "dd/mm/yyyy")]
        [Required(ErrorMessage = "Por favor seleccione la {0}")]
        [DataType(DataType.Text)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Remote("NotAfterToday", "Employees", ErrorMessage = "La {0} no puede ser posterior al día de hoy.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Es Freelance?")]
        public bool IsFreelance { get; set; }

        [Display(Name = "Impuestos")]
        [Column(TypeName = "Money")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal PayRate { get; set; }
    }
}