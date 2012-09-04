Cascade is a .NET library providing extension methods for method chaining. Method chaining is a technique to create consecutive method calls in a single line of code. This may help to reduce your code of lines and to improve readability.
The library is designed to be lightweight. The only dependency is the `mscorlib` assembly which is loaded anyway.

*Why* should I use this library? A good question. At first, all extensions provided by Cascade can be written in good ol' code too. However the extensions allow you writing shorter and code that can be better read.

*When* should I use this library? To be honest: You can use this library everywhere and at any time. There might be extensions you find useful especially when working with database values, or business objects.

# Example
This example provides a very first impression of Cascade and method chaining. Imagine you want to access a deeply nested property within your objects. As you know, a good programmer should always check for `null` references. This can be tedious work, just for getting a value.

*without cascade*

```cs
public object GetConfigurationValue(Configuration configuration, string sectionKey, string entryKey)
{
    if (configuration != null && configuration.Sections != null)
    {
        Section section = null;
        if (configuration.Sections.ContainsKey(sectionKey))
            section = configuration.Sections[sectionKey];

        if (section != null && section.Entries != null && section.Entries.ContainsKey(entryKey))
            return section.Entries[entryKey];
    }

    return null;
}
```
With help of Cascade extension methods you can reduce the code a little bit.

*with cascade*
```cs
public object GetConfigurationValue2(Configuration configuration, string sectionKey, string entryKey)
{
    return configuration.IfNotNull(x => x.Sections).Get(sectionKey).IfNotNull(x => x.Entries).Get(entryKey);
}
```

This one-liner do exactly the same as the method above. The example utilizes two Cascade extension methods `IfNotNull` and `Get`. While `IfNotNull` can be applied on all objects, `Get` is an dictionary extension.
`IfNotNull` checks whether the object itself is `null` or not. If the object is `null` the callback is not executed. In this case the extension is used to return property values if the parent is not null.
`Get` checks whether the dictionary is not null. If it is not null, it checks if it contains an entry with the given key and returns the value.

#Documentation
You can find a technical documentation of the extension methods in the https://github.com/jbuechner/cascade/wiki[wiki].

#License
Cascade is licensed under the https://github.com/jbuechner/cascade/wiki/License[Apache License 2.0]. Feel free to distribute and modify sources and binaries.