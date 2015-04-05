# Soltys.ChangeCase

Ported: https://www.npmjs.com/package/change-case to C#

## Installation 
```
  Install-Package Soltys.ChangeCase
```

## Usage
Add using:
```csharp
  using Soltys.ChangeCase
```

Sample usage:
```csharp
  string camelCase = "test string".CamelCase() // camelCase => testString
```

### SentenceCase()

```csharp
  string input = null;
  input.SentenceCase() //=> ""
  "string".SentenceCase(); //=> string
  "dot.case".SentenceCase(); //=> dot case
  "camelCase".SentenceCase(); //=> camel case
  "HELLO WORLD!".SentenceCase("_"); //=> hello_world
  "A STRING".SentenceCase(ci: CultureInfo.CreateSpecificCulture("tr")); //=> a strıng
```

### CamelCase()

```csharp
  string input = null;
  input.CamelCase() //=> ""
  "string".CamelCase(); //=> string
  "dot.case".CamelCase(); //=> dotCase
  "PascalCase".CamelCase(); //=> pascalCase
  "version 1.2.10".CamelCase(); //=> version1_2_10
  "STRING 1.2".CamelCase(ci: CultureInfo.CreateSpecificCulture("tr")); //=> strıng1_2
```

### PascalCase()

```csharp
  string input = null;
  input.PascalCase() //=> ""
  "string".PascalCase(); //=> String
  "dot.case".PascalCase(); //=> DotCase
  "camelCase".PascalCase(); //=> CamelCase
```

### UpperCaseFirst()

```csharp
  string input = null;
  input.UpperCaseFirst() //=> ""
  "string".UpperCaseFirst() //=> "String"
```

### LowerCaseFirst()

``` csharp
string input = null;
input.UpperCaseFirst() //=> ""
"STRING".UpperCaseFirst() //=> "sTRING"
```

### ParamCase()

```csharp
  string input = null;
  input.ParamCase() //=> ""
  "string".ParamCase(); //=> string
  "sentance case".ParamCase(); //=> sentance-case
  "camelCase".ParamCase(); //=> camel-case
```

### DotCase()

```csharp
  string input = null;
  input.DotCase() //=> ""
  "string".DotCase(); //=> string
  "sentance case".DotCase(); //=> sentance.case
  "camelCase".DotCase(); //=> camel.case
```

### SwapCase()

```csharp
  string input = null;
  input.SwapCase() //=> ""
  "string".SwapCase(); //=> STRING
  "PascalCase".SwapCase(); //=> pASCALcASE
  "Iñtërnâtiônàlizætiøn".SwapCase(); //=> iÑTËRNÂTIÔNÀLIZÆTIØN
```
