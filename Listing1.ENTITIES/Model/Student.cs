﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1.ENTITIES.Model
{
    /// <summary>
    ///     The AddStudent class
    /// </summary>
    /// <seealso cref="IEntityBase" />

    public class Customer : IEntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string ProfileImage { get; set; }



        //public string Name { get; set; }

        //public string Password { get; set; }

        //public string Email { get; set; }

        //public int Age { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
