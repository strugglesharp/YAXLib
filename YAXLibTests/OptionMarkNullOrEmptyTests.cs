﻿// Copyright (C) Sina Iravanian, Julian Verdurmen, axuno gGmbH and other contributors.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using YAXLib;
using YAXLib.Customization;
using YAXLib.Enums;
using YAXLib.Options;
using YAXLibTests.SampleClasses;

namespace YAXLibTests;

[TestFixture]
public class OptionMarkNullOrEmptyTests
{
    /// <summary>
    /// Testing for  option of YAXSerializationOptions.MarkNullOrEmpty
    /// </summary> 
    public class NullableSample4
    {
        public string? Text01 { get; set; }
        public string? Text02 { get; set; }
        public List<int> TheCollection01 { get; set; }
        public List<int> TheCollection02 { get; set; }

        public static NullableSample4 GetSampleInstance()
        {
            return new()
            {
                Text01 = "",
                Text02 = null,
                TheCollection01 = new List<int> { },
                TheCollection02 = null,
            };
        }
    }
    [Test]
    public void Serialize01()
    {
        const string result = """
                <NullableSample4>
                  <Text01></Text01>
                  <Text02 _MarkNullOrEmpty="NULL" />
                  <TheCollection01 _MarkNullOrEmpty="EMPTY" />
                  <TheCollection02 _MarkNullOrEmpty="NULL" />
                </NullableSample4>
                """;

        var serializer = new YAXSerializer<NullableSample4>(new SerializerOptions
        {
            SerializationOptions = YAXSerializationOptions.MarkNullOrEmpty
        });
        var instance = NullableSample4.GetSampleInstance();
        var got = serializer.Serialize(instance); 
        Assert.AreEqual(got, result);
    }

 
}
