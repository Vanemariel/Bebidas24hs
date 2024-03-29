﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebidas24hs.DataBase.Data.Comun
{
    [Index(nameof(Id), Name = "Entity_Id", IsUnique = true)]
    public class BaseEntity
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        public int Id { get; set; }
    }
}
