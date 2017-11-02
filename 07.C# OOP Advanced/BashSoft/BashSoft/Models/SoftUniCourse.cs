﻿namespace BashSoft.Models
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using System.Collections.Generic;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return this.studentsByName; }
        }

        public void EnrollStudent(IStudent softUniStudent)
        {
            if (this.studentsByName.ContainsKey(softUniStudent.UserName))
            {
                throw new DuplicateEntryInStructureException(softUniStudent.UserName, this.Name);
            }

            this.studentsByName.Add(softUniStudent.UserName, softUniStudent);
        }

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

        public override string ToString() => this.Name;
    }
}