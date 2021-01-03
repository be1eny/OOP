using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class BelBook //класс белкнига
    {
        public string BelAuthor { get; set; }
        public string BelTitle { get; set; }
        public BelBook(string belAuthor, string belTitle)
        {
            BelAuthor = belAuthor;
            BelTitle = belTitle;
        }
    }
    class Player //класс игрок
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team //класс команда 
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class Book //класс книга 
    { 
        public string title; //переменные книги
        public string author;
        private string publishingHouse;
        public ushort year;
        private uint pageNumber;
        private uint cost;
        private string blindingType;
        private int blindingTypeNumber;
        public Book(string title, string author, string publishingHouse, ushort year, uint pageNumber, uint cost, string blindingType, int blindingTypeNumber)
        {
            this.title = title; //задание значений свойствам 
            this.author = author;
            this.publishingHouse = publishingHouse;
            this.year = year;
            this.pageNumber = pageNumber;
            this.cost = cost;
            this.blindingType = blindingType;
            this.blindingTypeNumber = blindingTypeNumber;
        }
        public string Title //название
        {
            get { return title; }
            set { title = value; }
        }
        public string Author //автор 
        {
            get { return author; }
            set { author = value; }
        }
        public string PublishingHouse //страна
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }
        public ushort Year //год 
        {
            get { return year; }
            set
            {
                if (year <= 2020)
                    year = value;
                else year = 0;
            }
        }
        public uint PageNumber //кол-во страниц
        {
            get { return pageNumber; }
            set { pageNumber = value; }
        }
        public uint Cost //цена
        { 
            get { return cost; }
            set { cost = value; }
        }
        public string BlindingType //тип переплета
        {
            get { return blindingType; }
            set { blindingType = value; }
        }
        public int BlindingTypeNumber //номер типа
        {
            get { return blindingTypeNumber; }
            set { blindingTypeNumber = value; }
        }
    }
}


