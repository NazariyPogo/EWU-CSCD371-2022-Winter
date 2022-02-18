using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

    [TestClass]
public class MyTestClass
{
    [TestMethod]
    public void Import_SeeIfFileWrittenIntoArray()
    {
        SampleData SampleData = new();
        Assert.IsTrue(SampleData.CsvRows.Count() == 50);
        Assert.IsTrue(SampleData.CsvRows.Contains("12,Vince,Dee,vdeeb@japanpost.jp,98027 Ridgeview Lane,Houston,TX,67224"));
        Assert.IsTrue(SampleData.CsvRows.ElementAt(11) == "12,Vince,Dee,vdeeb@japanpost.jp,98027 Ridgeview Lane,Houston,TX,67224");
    }

    [TestMethod]
    public void Part2_TestingForSortUsingHardcodedList()
    {
        SampleData sampleData = new();
    }

    [TestMethod]
    public void Part2_TestingForSortUsingLINQ()
    {
        SampleData sampleData = new();
    }

    [TestMethod]
    public void Part3_()
    {
        SampleData sampleData = new();
    }

    [TestMethod]
    public void Part4_PeopleListCreated()
    {
        SampleData sampleData = new();
    }

    [TestMethod]
    public void Part4_EachPersonHasAnAddress()
    {
        SampleData sampleData = new();
    }

    [TestMethod]
    public void Part5_()
    {
        SampleData sampleData = new();
    }

    [TestMethod]
    public void Part6_()
    {
        SampleData sampleData = new();
    }

}
