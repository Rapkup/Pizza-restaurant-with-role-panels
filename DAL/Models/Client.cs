using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Client 
    {
        public int Id { get; set; }
        public string Name { get; set; }    
       
        public string LastName { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Client(int id, string name, string surname, string addres, string numb)
        {
            Id = id;
            Name = name;
            LastName = surname;
            Address = addres;
            PhoneNumber = numb;
        }

        public Client(string name, string surname, string addres, string numb)
        {

            Name = name;
            LastName = surname;
            Address = addres;
            PhoneNumber = numb;
        }

        public Client()
        {

        }
    }
}
