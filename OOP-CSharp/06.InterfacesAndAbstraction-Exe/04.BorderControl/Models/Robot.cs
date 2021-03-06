using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Robot : Id
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
