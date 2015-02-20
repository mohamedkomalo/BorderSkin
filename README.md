# BorderSkin

Border Skin is a free portable software to skin the windows borders by skins composed of png images with the support of several features like Blur, Reflection and Aero Explorer, it supports Windows XP/Vista/7/8.

# Getting Started
You will need Visual Studio to work with the project, I use Visual Studio 2013 but I think previous versions can work too.
That's it, just open solution and build it

# Project History
BorderSkin was originally written in [AutoIt] but never release in this language, then it was converted into VB.NET until 0.2.9, then from 0.3 it was converted into C# and some functionality were extracted as separate libraries ([LayeredForms], [WindowsHook], [WinApiWrappers])

# New Goal
The original purpose of BorderSkin was to simulate aero interface on windows xp. however with the upcoming release of windows 10, this doesn't really have much value anymore, so there must be a new vision to work towards to.

One of the top features that distinguished BorderSkin was Aero Explorer, because it added real the vista explorer controls like breadcrumbs on the borders of XP explorer windows. 

However, the real power of this feature wasn't just the vista controls, but the ability of creating custom controls and put them on the windows borders.

So the new goal is to provide the ability through plugins to create custom controls to be added on windows borders, whether these controls was to specific window type (like explorer) or for all windows.

Of course the normal features like blur are still maintained.

If you have an idea (even if it was a small one) of what BorderSkin goal can be, please don't hesitate to discuss it in the [GOAL issue] or send me by email.

# Contributing
* Consider contributing to [LayeredForms], [WindowsHook], [WinApiWrappers]
* Create a new issue to report a bug or suggest a feature
* Checkout the opened issues, if you decided to work on an issue, please comment.


# License
BorderSkin project is released under MIT license, other projects used are released under their own license.

[GOAL issue]:https://github.com/mohamedkomalo/BorderSkin/issues/1

[AutoIt]:https://github.com/mohamedkomalo/BorderSkin-AutoIt

[LayeredForms]:https://github.com/mohamedkomalo/LayeredForms

[WindowsHook]:https://github.com/mohamedkomalo/WindowsHook

[WinApiWrappers]:https://github.com/mohamedkomalo/WinApiWrappers
