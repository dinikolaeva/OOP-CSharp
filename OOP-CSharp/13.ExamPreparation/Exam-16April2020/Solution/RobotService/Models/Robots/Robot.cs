﻿using RobotService.Models.Robots.Contracts;
using System;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public int Energy
        { 
            get => this.energy; 
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            } 
        }

        public int ProcedureTime { get; set; }

        public virtual string Owner { get; set; } = "Service";//?

        public bool IsBought { get; set; } = false;

        public bool IsChipped { get; set; } = false;

        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.happiness} - Energy: {this.Energy}";
        }
    }
}
