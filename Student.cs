using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_15___Exercitiu
{
    class Student
    {
        public Guid Id { get; private set; }

        public Student()
        {
            Id = Guid.NewGuid();
        }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public MajorType Major { get; set; }

        public override string ToString() =>
            $"Id: {Id} \n Forename: {Forename} \n Surname: {Surname} \n Age: {Age} \n Major: {Major}";
    }
}
