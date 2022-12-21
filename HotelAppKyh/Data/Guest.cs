using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Data
{
    public class Guest
    {
        public int GuestId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? PhoneNumber  { get; set; }

        public void NewGuestProps(string _firstName, string _lastName, string _phoneNumber)
        {

            FirstName = _firstName;
            LastName = _lastName;
            PhoneNumber = _phoneNumber;


        }



    }

    }

