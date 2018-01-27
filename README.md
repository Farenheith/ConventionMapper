# ConventionMapper
Mapping generation project based on naming convetion with focus on performance and simplicity

This is not an auto mapper runtime generator. To use this solution, you'll need to create a console application (.NET Framework) with the purpose to generate the source code desidred. Here's an example of said generation:

```csharp
public static void Main(string[] args) {
  var modelToViewModel = MappingGenerator.Create<ModelBase, ViewModelBase>("MyProject.ViewModel");
  var viewModelToModel = modelToViewModel.GetReverse("Model");
  modelToViewModel.Generate();
}
```

This two lines of code will generate all the mapping you need to your entities under the limitation of the conventions expected.
The conventions are:

* All mapped types are classes with public constructors that take no arguments
* All properties of both classes are composed by value types, classes to be mapped or ICollections of classes to be mapped. Anything other than that will generate an error or unexpected behavior at the current stage of the project;
* There is a strict naming rule between class properties, ie, properties with the same name have the same types, or types to be mapped to each other. Regardless, properties with no counterpart are accepted but will not be mapped;

The following rules applies for the example of generation given above, but it can be more flexible:

* There's a base class for all source classes you need to map;
* There's another base class for all destination classes you need to map unrelated with the source base class;
* There is a strict naming rule between classes where destination classes ends with the final part of they own namespace. For example, in the code above is expected that the model classes have names like Person, Product and Invoice, while the viewmodel classes should be named like PersonViewModel, ProductViewModel, InvoiceViewModel, and their namespace must be MyProject.ViewModel;

# Installation

For now you need to download the sourcecode and compile it yourself but I'll make it available via Nuget asap. ConventionMapper.Generator.dll is only needed at the generation project while ConventionMapper.dll are needed in any project you'll use.

The project ConventionMapper is made under the .NET Standard, so I expect you'll don't need to worry about any compatibility issue, but ConventionMapper.Generator needed to be made with .NET Framework because of T4 template generators. Be warned.

# Generation

The generated files will be saved at output folder in the same folder of the binaries of the generation project, separated by folders with namespace name, ready to be copied and pasted at your own project.

# Using the mappings

To use the mapping, you need to first initialize the mapper at your project, like this:

```csharp
Mapper.Load<PivotType>();
```

Where PivotType is just a reference to help ConventionMapper to find in which binaries the mapping classes are. Just inform any class present in that binary and you're good to go. If you choose to let your mapping classes in separated binaries you need to call the Load method for each binary.

After that, all you need is to do the map:

```csharp
var viewModel = Mapper.Map<ClassViewModel>(instance);
```

ConventionMapper will treat automatically cyclical references using a temporary cache that will be disposed as soon the map is finished. 

Each time you call the static method Map a new instance of each needed map is created to attend the desired purpose. If there is no mapping loaded to the given entity, you'll get an InvalidOperationException.

If you're planning to do a big amount of maps of the same type, is recommended to obtain the specific mapping instance itself and do all the maps, like this:

```csharp
var mapping = Mapper.Get<ClassModel, ClassViewModel>();

var viewModel = mapping.Map(instance);
```

There are ways to use ConventionMapper with more freedom that will be explained ASAP, or you can look into the source code and figure out by yourself!

# Customizing specific mappings

All classes generated are partial so you can write your own counterpart to make some specific treatment if you need.
To do so, just override the TreatResult method and do wathever you need to.
