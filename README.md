**Punch** is a small open-source library that brings the wonders of strongly-typed helpers to declare [Knockout JS](http://knockoutjs.com/) bindings in your ASP MVC Razor views. It also comes with a set of handy html helpers to render common html tags.

It was designed to work within and reinforce the [MVVM pattern](http://en.wikipedia.org/wiki/Model_View_ViewModel). 

Punch was inspired by [Knockout MVC](http://knockoutmvc.com/), but with none all the server -> client logic conversion. You have to still create your JavaScript viewmodels by hand or by other means. 

### How do I get it?

You can easily install it directly from NuGet:

`PM> Install-Package Punch.Helpers`

### Can I extend it?

It can be easily extended to 

* create your custom bindings, 
* add your own html helpers,
* intercept tag render to customize the output,
* configure your bindings declaratively

### What if I have a problem or doubt?

First, check out if you can find your answer in the [documentation] [wiki]. You can post your question in [StackOverflow](http://www.stackoverflow.com), and please don't forget to include the Punch tag. You can also create an issue in the [GitHub repo](https://github.com/hernangm/punch/issues/new) to report a bug or request a feature.




[wiki]: https://github.com/hernangm/punch/wiki
