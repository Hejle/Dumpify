﻿using Dumpify;
using Spectre.Console;

using System.Collections;
using System.Data;
using System.Reflection;
using System.Text;

//DumpConfig.Default.Renderer = Renderers.Text;
//DumpConfig.Default.ColorConfig = ColorConfig.NoColors;

//DumpConfig.Default.Output = Outputs.Debug;

Console.WriteLine("---------------------");
TestParticular();
// TestSingle();
// ShowEverything();

#pragma warning disable CS8321
void TestParticular()
{
    // Guid.NewGuid().Dump(members: new MembersConfig { IncludeNonPublicMembers = true, IncludeFields = true });
    // new NullReferenceException("sfsdf", new ArgumentNullException("bbbbb")).Dump();

    // "This is string".Dump("Label1");
    // var arr3d = new int[,,] { { { 1, 2, 22 }, { 3, 4, 44 } }, { { 5, 6, 66 }, { 7, 8, 88 } }, { { 9, 10, 1010 }, { 11, 12, 1212 } } }.Dump();
    //var moaid = new Person { FirstName = "Moaid", LastName = "Hathot", Profession = Profession.Software };
    //var haneeni = new Person { FirstName = "Haneeni", LastName = "Shibli", Profession = Profession.Health };
    //moaid.Spouse = haneeni;
    //haneeni.Spouse = moaid;
    //var family = new Family
    //{
    //    Parent1 = moaid,
    //    Parent2 = haneeni,
    //    FamilyId = 42,
    //    ChildrenArray = new[] { new Person { FirstName = "Child1", LastName = "Hathot" }, new Person { FirstName = "Child2", LastName = "Hathot", Spouse = new Person { FirstName = "Child22", LastName = "Hathot", Spouse = new Person { FirstName = "Child222", LastName = "Hathot" } } } },
    //    ChildrenList = new List<Person> { new Person { FirstName = "Child1", LastName = "Hathot" }, new Person { FirstName = "Child2", LastName = "Hathot" } },
    //    ChildrenArrayList = new ArrayList { new Person { FirstName = "Child1", LastName = "Hathot" }, new Person { FirstName = "Child2", LastName = "Hathot" } },
    //    FamilyType = typeof(Family),
    //    FamilyNameBuilder = new StringBuilder("This is the built Family Name"),
    //}.DumpText();


    //File.WriteAllText(@"S:\Programming\Github\Dumpify\textDump.txt", family);
    var options = new OptionsA { StrProp = "PropA*", IntProp = 3, OptBProp = new OptionsB { Op2StrProp = "Prop2B*", OptCProp = new OptionsC { Opt3IntProp = 666, } }, };

    var generator = new ConfigGenerator();
    var result = generator.Generate(options);

    // new List<int> { 1, 2, 3, 4 }.Dump(members: new MembersConfig { IncludeFields = true, IncludeNonPublicMembers = true });
    //typeof(TypeEvaluator).GetProperties().Dump();



}

void TestSingle()
{

    new { Name = "Dumpify", Description = "Dump any object to Console" }.Dump();

    DateTime.Now.Dump();
    DateTime.UtcNow.Dump();
    DateTimeOffset.Now.Dump();
    DateTimeOffset.UtcNow.Dump();
    TimeSpan.FromSeconds(10).Dump();

    var moaid = new Person { FirstName = "Moaid", LastName = "Hathot", Profession = Profession.Software };
    var haneeni = new Person { FirstName = "Haneeni", LastName = "Shibli", Profession = Profession.Health };
    moaid.Spouse = haneeni;
    haneeni.Spouse = moaid;

    ("ItemA", "ItemB").Dump();
    Tuple.Create("ItemAA", "ItemBB").Dump();

    // moaid.Dump(typeNames: new TypeNamingConfig { ShowTypeNames = false }, tableConfig: new TableConfig { ShowTableHeaders = false });

    // var s = Enumerable.Range(0, 10).Select(i => $"#{i}").Dump();
    // string.Join(", ", s).Dump();

    //Test().Dump();

    //IPAddress.IPv6Any.Dump();

    var map = new Dictionary<string, string>();
    map.Add("One", "1");
    map.Add("Two", "2");
    map.Add("Three", "3");
    map.Add("Four", "4");
    map.Add("Five", "5");
    map.Dump();


    var map2 = new Dictionary<string, Person>();
    map2.Add("Moaid", new Person { FirstName = "Moaid", LastName = "Hathot" });
    map2.Add("Haneeni", new Person { FirstName = "Haneeni", LastName = "Shibli" });
    map2.Dump("Test Label");

    //
    // map.Dump(map.GetType().Name);
    //
    //
    // map.Add("Five", "5");
    // map.Add("Six", "6");
    //
    // map.Add("Seven", "7");
    // // test.Sum(a => a.);
    //
    // var map2 = new ConcurrentDictionary<string, string>();
    // map2.TryAdd("One", "1");
    // map2.TryAdd("Two", "2");
    // map2.TryAdd("Three", "3");
    // map2.TryAdd("Four", "4");
    // map2.Dump(map2.GetType().Name);
    //
    //
    //
    // var test = new Test();
    // test.Add(new KeyValuePair<string, int>("One", 1));
    // test.Add(new KeyValuePair<string, int>("Two", 2));
    // test.Add(new KeyValuePair<string, int>("Three", 3));
    // test.Add(new KeyValuePair<string, int>("Four", 4));
    // test.Add(new KeyValuePair<string, int>("Five", 5));
    // test.Dump();
    //
    //
    // test.Dump(test.GetType().Name);
    //
    // async IAsyncEnumerable<int> Test()
    // {
    //     await Task.Yield();
    //     yield return 1;
    //     yield return 2;
    //     yield return 3;
    //     yield return 4;
    // }

    // new[] { new { Foo = moaid }, new { Foo = moaid }, new { Foo = moaid } }.Dump(label: "bla");

    var dataTable = new DataTable("Moaid Table");
    dataTable.Columns.Add("A");
    dataTable.Columns.Add("B");
    dataTable.Columns.Add("C");

    dataTable.Rows.Add("a", "b", "c");
    dataTable.Rows.Add("A", "B", "C");
    dataTable.Rows.Add("1", "2", "3");

    dataTable.Dump("Test Label 2");

    var set = new DataSet();

    set.Tables.Add(dataTable);
    set.Dump("Test Label 3");

    var arr = new[] { 1, 2, 3, 4 }.Dump();
    var arr2d = new int[,] { { 1, 2 }, { 3, 4 } }.Dump();
    var arr3d = new int[,,] { { { 1, 2 }, { 3, 4 } }, { { 3, 4 }, { 5, 6 } }, { { 6, 7 }, { 8, 9 } } }.Dump();
}

void ShowEverything()
{
    var moaid = new Person { FirstName = "Moaid", LastName = "Hathot", Profession = Profession.Software };
    var haneeni = new Person { FirstName = "Haneeni", LastName = "Shibli", Profession = Profession.Health };
    moaid.Spouse = haneeni;
    haneeni.Spouse = moaid;


    //DumpConfig.Default.Output = Outputs.Debug; //Outputs.Trace, Outputs.Console
    //moaid.Dump(output: Outputs.Trace);
    //moaid.DumpDebug();
    //moaid.DumpTrace();

    //moaid.Dump(output: myCustomOutput);


    DumpConfig.Default.TypeNamingConfig.UseAliases = true;
    DumpConfig.Default.TypeNamingConfig.UseFullName = true;

    moaid.Dump(typeNames: new TypeNamingConfig { UseAliases = true, ShowTypeNames = false });

    moaid.Dump();

    var family = new Family
    {
        Parent1 = moaid,
        Parent2 = haneeni,
        FamilyId = 42,
        ChildrenArray = new[] { new Person { FirstName = "Child1", LastName = "Hathot" }, new Person { FirstName = "Child2", LastName = "Hathot", Spouse = new Person { FirstName = "Child22", LastName = "Hathot", Spouse = new Person { FirstName = "Child222", LastName = "Hathot" } } } },
        ChildrenList = new List<Person> { new Person { FirstName = "Child1", LastName = "Hathot" }, new Person { FirstName = "Child2", LastName = "Hathot" } },
        ChildrenArrayList = new ArrayList { new Person { FirstName = "Child1", LastName = "Hathot" }, new Person { FirstName = "Child2", LastName = "Hathot" } },
        FamilyType = typeof(Family),
        FamilyNameBuilder = new StringBuilder("This is the built Family Name"),
    };

    System.Tuple.Create(10, 55, "hello").Dump();
    (10, "hello").Dump();

    var f = () => 10;
    // f.Dump();

    family.Dump(label: "This is my family label");

    new HashSet<string> { "A", "B", "C", "A" }.Dump();

    var stack = new Stack<int>();
    stack.Push(1);
    stack.Push(2);
    stack.Push(3);
    stack.Push(4);
    stack.Push(5);

    stack.Dump();


    moaid.Dump(tableConfig: new TableConfig { ShowTableHeaders = false }, typeNames: new TypeNamingConfig { ShowTypeNames = false });
    moaid.Dump();

    new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 } }.Dump();

    //moaid.Dump(label: "Test");
    //moaid.Dump();

    //new { Name = "MyBook", Author = new { FirstName = "Moaid", LastName = "Hathot", Address = new { Email = "moaid@test.com" } } }.Dump(maxDepth: 7, showTypeNames: true, showHeaders: true);
    //moaid.Dump();

    //DumpConfig.Default.ShowTypeNames = false;
    //DumpConfig.Default.ShowHeaders = false;

    //DumpConfig.Default.Generator.Generate(new { Name = "MyBook", Author = new { FirstName = "Moaid", LastName = "Hathot", Address = new { Email = "moaid@test.com" } } }.GetType(), null).Dump();
    //moaid.Dump();

    new { Name = "Dumpify", Description = "Dump any object to Console" }.Dump();
    //new HashSet<string> { "Moaid", "Hathot", "shibli" }.Dump();


    new Dictionary<Person, string> { [new Person { FirstName = "Moaid", LastName = "Hathot" }] = "Moaid Hathot", [new Person { FirstName = "Haneeni", LastName = "Shibli" }] = "Haneeni Shibli", [new Person { FirstName = "Waseem", LastName = "Hathot" }] = "Waseem Hathot", }.Dump();


    new Dictionary<string, Person> { ["Moaid"] = new Person { FirstName = "Moaid", LastName = "Hathot" }, ["Haneeni"] = new Person { FirstName = "Haneeni", LastName = "Shibli" }, ["Waseem"] = new Person { FirstName = "Waseem", LastName = "Hathot" }, }.Dump(colors: ColorConfig.NoColors);


    new Dictionary<string, string>
    {
        ["Moaid"] = "Hathot",
        ["Haneeni"] = "Shibli",
        ["Eren"] = "Yeager",
        ["Mikasa"] = "Ackerman",
    }.Dump();

    //ItemOrder.First.Dump();
    //var d = DumpConfig.Default.Generator.Generate(ItemOrder.First.GetType(), null);
    //d.Dump();


    //var ao = new
    //{
    //    DateTime = DateTime.Now,
    //    DateTimeUtc = DateTime.UtcNow,
    //    DateTimeOffset = DateTimeOffset.Now,
    //    DateOnly = DateOnly.FromDateTime(DateTime.Now),
    //    TimeOnly = TimeOnly.FromDateTime(DateTime.Now),
    //    TimeSpan = TimeSpan.FromMicroseconds(30324),
    //}.Dump();

    //var d = DumpConfig.Default.Generator.Generate(ao.GetType(), null);
    //d.Dump();

    //DumpConfig.Default.Generator.Generate(typeof(Family), null).Dump();

    //var arr = new[,,] { { { 1, 2, 4 } }, { { 3, 4, 6 } }, { {1, 2, 88 } } }.Dump();

    var arr = new[] { 1, 2, 3, 4 }.Dump();
    var arr2d = new int[,] { { 1, 2 }, { 3, 4 } }.Dump();


    DumpConfig.Default.TableConfig.ShowArrayIndices = false;

    arr.Dump();
    arr2d.Dump();

    DumpConfig.Default.TableConfig.ShowArrayIndices = true;

    moaid.Dump();

    //new[] { "Hello", "World", "This", "Is", "Dumpy" }.Dump(renderer: Renderers.Text);

    new Exception("This is an exception", new ArgumentNullException("blaParam", "This is inner exception")).Dump();

    new AdditionValue(1, 10).Dump(members: new() { IncludeFields = true, IncludeNonPublicMembers = true, IncludeProperties = false });
    new AdditionValue(1, 10).Dump(members: new() { IncludeFields = true, IncludeNonPublicMembers = true });

    //arr.Dump();
    //moaid.Dump();


    //family.Dump(maxDepth: 2);

    //Console.WriteLine(JsonSerializer.Serialize(moaid));


    //moaid.Dump();
    //arr2d.Dump();

    //moaid.Dump(maxDepth: 2);
    //family.Dump(maxDepth: 2);
    //arr.Dump();
    //arr2d.Dump();
    //((object)null).Dump();

    //var result = DumpConfig.Default.Generator.Generate(family.GetType(), null);

    //JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
}
#pragma warning restore CS8321

public enum Profession { Software, Health };
public record class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public Person? Spouse { get; set; }

    public Profession Profession { get; set; }
}

public class Family
{
    public Person? Parent1 { get; set; }
    public Person? Parent2 { get; set; }

    public int FamilyId { get; set; }

    public Person[]? ChildrenArray { get; set; }
    public List<Person>? ChildrenList { get; set; }
    public ArrayList? ChildrenArrayList { get; set; }

    public Type? FamilyType { get; set; }

    public StringBuilder? FamilyNameBuilder { get; set; }
}

public record class Book(string[] Authors);

public class AdditionValue
{
    private readonly int _a;
    private readonly int _b;

    public AdditionValue(int a, int b)
    {
        _a = a;
        _b = b;
    }

    private int Value => _a + _b;
}

public class Device
{
    public bool isPowered { get; set; }
}


class Test : ICollection<KeyValuePair<string, int>>
{
    private List<(string key, int value)> _list = new();

    public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        => _list.Select(l => new KeyValuePair<string, int>(l.key, l.value)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public void Add(KeyValuePair<string, int> item)
        => _list.Add((item.Key, item.Value));

    public void Clear()
        => _list.Clear();

    public bool Contains(KeyValuePair<string, int> item)
        => _list.Contains((item.Key, item.Value));

    public void CopyTo(KeyValuePair<string, int>[] array, int arrayIndex)
        => throw new NotImplementedException();

    public bool Remove(KeyValuePair<string, int> item)
        => throw new NotImplementedException();

    public int Count => _list.Count;
    public bool IsReadOnly { get; } = false;
}

;




public class OptionsA
{
    public string? StrProp { get; set; }
    public int? IntProp { get; set; }
    public OptionsB? OptBProp { get; set; }
}

public class OptionsB
{
    public string? Op2StrProp { get; set; }
    public OptionsC? OptCProp { get; set; }
}

public class OptionsC
{
    public int Opt3IntProp { get; set; }
}


public class ConfigGenerator
{
    private Dictionary<Type, TypeEvaluator> _evaluators = new();

    public IEnumerable<string> Generate(object obj)
    {
        if (!_evaluators.TryGetValue(obj.GetType(), out var evaluator))
        {
            evaluator = CreatePropertyEvaluator(obj);
            _evaluators.Add(obj.GetType(), evaluator);
        }

        evaluator.Dump(members: new MembersConfig { IncludeNonPublicMembers = true, IncludeFields = true });

        foreach (var i in evaluator.properties)
        {
            Console.WriteLine(i.evaluator.GetValue(obj));
        }

        return Enumerable.Empty<string>();
    }

    private TypeEvaluator CreatePropertyEvaluator(object obj)
    {
        var type = obj.GetType();

        var stack = new Queue<(Type type, CompositePropertyEvaluator evaluator)>();

        stack.Enqueue((type, new CompositePropertyEvaluator(null, null)));

        var list = new List<(string path, CompositePropertyEvaluator evaluator)>(5);

        while (stack.Any())
        {
            var tuple = stack.Dequeue();

            if (tuple.type == typeof(int) || tuple.type == typeof(string) || tuple.type == typeof(bool))
            {
                list.Add(("", tuple.evaluator));
                continue;
            }

            var properties = tuple.type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                stack.Enqueue((property.PropertyType, new CompositePropertyEvaluator(property, tuple.evaluator)));
            }
        }

        return new TypeEvaluator(type, list);
    }
}

internal record TypeEvaluator(Type Type, List<(string path, CompositePropertyEvaluator evaluator)> properties);

internal class CompositePropertyEvaluator
{
    private PropertyInfo? _propertyInfo;
    private readonly CompositePropertyEvaluator? _parentEvaluator;

    public CompositePropertyEvaluator(PropertyInfo? propertyInfo, CompositePropertyEvaluator? parentEvaluator)
    {
        _propertyInfo = propertyInfo;
        _parentEvaluator = parentEvaluator;
    }

    public object? GetValue(object obj)
    {
        object? value = obj;

        if (_parentEvaluator is not null)
        {
            value = _parentEvaluator.GetValue(value);
        }

        return GetPropertyValue(value);
    }

    private object? GetPropertyValue(object? obj)
    {
        if (obj is null)
        {
            return null;
        }

        return _propertyInfo switch
        {
            null => obj,
            { } evaluator => evaluator.GetValue(obj)
        };
    }
}