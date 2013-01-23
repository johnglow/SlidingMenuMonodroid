SlidingMenuMonodroid
===========================

This is a Mono for Android binding to the Android [SlidingMenu][2] Library project. 

I have only ported a simple example so far but I am going to try and port some more [complex examples][3] That way I should be able to tell if the binding is not missing anything.

SlidingMenu has an optional dependancy on ActionBarSherlock so I am not too sure yet if I need to include actionbarsherlock.jar and android-support-v4.jar in the binding as Reference Jars (Build Action to 'ReferenceJar'). 

Recommended reading and research
===========================

Learn [How to build the JAR files from source][6]. You have to use eclipse to do this step, so follow the instructions on how to set that up. While you are at it make sure you can get the Sliding menu example working! If you are having trouble with this ping me on twitter [@jakescott][8] and I will happily give you a hand. When you grab the jar files from the /library/bin folder you need to add them to your own zip file. Take a look at the [directory structure of my zip file][7] as it is important!
Then learn [How to bind a Android Library Project][1]. 

Have a look at the [Mono for Android bindings][4] to [ActionBarSherlock][5]. These were done by xamarin dudes.

Cavets
===========================

No Intellisense yet in VisualStudio and MonoDevelop. [This is a known issue][9]. But don't worry you should be able to work it out by reading the java source code and also download a copy of [Jetbrains dotpeek][10] so that you can decompile your bindings so that you can see how the bindings were translated from Java to C#.

I also ran into a problem with trying to port the animation samples.. [read about it here][11]. The Xamarin guys came to the rescue.


Credits:
===========================
Jeremy Feinstein, and any other people who have worked on SlidingMenu.
https://github.com/jfeinstein10/SlidingMenu/


[1]: http://docs.xamarin.com/Android/Guides/Advanced_Topics/Java_Integration_Overview/Binding_a_Java_Library_(.jar)#Android_Library_Projects
[2]: https://github.com/jfeinstein10/SlidingMenu/
[3]: https://github.com/jfeinstein10/SlidingMenu/tree/master/example/src/com/slidingmenu/example
[4]: https://github.com/xamarin/monodroid-samples/tree/master/ActionBarSherlock/ActionBarSherlock
[5]: http://actionbarsherlock.com
[6]: http://www.craigsprogramming.com/2012/07/actionbarsherlock-with-mono-for-android.html
[7]: https://github.com/superlogical/SlidingMenuMonodroid/raw/master/SlidingMenuBinding/Jars/SlidingMenu.zip     
[8]: http://twitter.com/jakescott
[9]: http://forums.xamarin.com/discussion/comment/2636#Comment_2636
[10]: http://www.jetbrains.com/decompiler/
