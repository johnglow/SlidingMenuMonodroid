SlidingMenuMonodroid
===========================

This is a Mono for Android binding to the Android [SlidingMenu][2] Library project. 

**IMPORTANT:** You will need to checkout the latest source code for SlidingMenu and ActionBarSherlock so that you can generate dlls from the ActionBarSherlock and SlidingMenu library projects. Find out more about binding to Android Library projects [here][1].

SlidingMenu has an optional dependancy on [ActionBarSherlock][5] and I am using this in my demo because I want to be able to support Gingerbread 2.3.3 API level 10.  All you have to do is check out a clean version of ABS. Add it as a dependency to the library and then make SlidingFragmentActivity extend SherlockFragmentActivity instead. [Here is a quote from an issue on Github][12]: "This is not something that will be in the repository, but rather something you must set up on your own. We moved the project away from forcing an ABS dependency, but you can still use ABS like this. I'm actually doing this same process for one of my apps."

Recommended reading and research
===========================

Learn [How to build the JAR files from source][6]. You have to use eclipse to do this step, so follow the instructions on how to set that up. While you are at it make sure you can get the Sliding menu example working! If you are having trouble with this ping me on twitter [@jakescott][8] and I will happily give you a hand. When you grab the jar files from the /library/bin folder you need to add them to your own zip file. Take a look at the [directory structure of my zip file][7] as it is important!
Then learn [How to bind a Android Library Project][1]. 


Credits
===========================
Jeremy Feinstein, and any other people who have worked on SlidingMenu.
https://github.com/jfeinstein10/SlidingMenu/

[1]: http://docs.xamarin.com/Android/Guides/Advanced_Topics/Java_Integration_Overview/Binding_a_Java_Library_(.jar)#Android_Library_Projects
[2]: https://github.com/jfeinstein10/SlidingMenu/
[3]: https://github.com/jfeinstein10/SlidingMenu/tree/master/example/src/com/slidingmenu/example
[4]: https://github.com/xamarin/monodroid-samples/tree/master/ActionBarSherlock/ActionBarSherlock
[5]: http://actionbarsherlock.com
[6]: http://www.craigsprogramming.com/2012/07/actionbarsherlock-with-mono-for-android.html
[7]: https://github.com/superlogical/SlidingMenuMonodroid/raw/master/SlidingMenuBinding/SlidingMenu.zip   
[8]: http://twitter.com/jakescott
[9]: http://forums.xamarin.com/discussion/comment/2636#Comment_2636
[10]: http://www.jetbrains.com/decompiler/
[11]: http://forums.xamarin.com/discussion/878/slidingmenu-binding-error-missing-class-error-was-raised-while-reflecting-setbehindcanvastransforme#latest
[12]: https://github.com/jfeinstein10/SlidingMenu/issues/22

