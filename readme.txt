Hello, mimicore3.1 is a .NET core web application, which is built in Visual Studio 2019 with .NET Core 3.1.

In this application it is using Vue.js as the front end framework to build a SPA (Single Page Application). It is a mini app and the major purpose is to demo the usage of Vue in .NET core environment, so it won't be quite complicated. I only implement the basic features. Don't complain if you feel some thing might be missing!

The backend is not the major point of this project, it behaves more like a simple REST API. There is not database usage either, I hardcode some data from C#.

In the begining, I did not expect it becomes so big (fine it may looks simple on UI). However as I am developing it, more and more ideas come to me and I cannot reject to implement them. It is also in such a procedure I have deeper learning and understanding on the Vue design.

Please be aware, this is a SPA app, so the view files under Views folder are very simple (just a simple HTML page), and it will be updated automatically when the front end source codes are compiled. DO NOT write any content into them. Right now I have exclude those files in the .gitignore, and only keep the empty folders.

During the development, I try to demo these pratices of Vue.js:
1. Component creation and usage (I did a two-levels supported dropdown list, a lot of fun!)
2. Slot
3. Directive
4. Third party Vue component
5. Transition for element change animation
6. Axios for API calling
7. Vue-router for routing
8. Vuex to store the common state info like user's profile and and many other modules.
9. Webpack for front end codes compiling and packaging.

There are also some small tricks I like to share:
1. A css class "ellipsisText" to help automatically truncate long strings to fit the width and show "..." at the end. Usually its parent div should also be defined "display: flex; overflow: hidden".

To run the app
1. First you need to compile the front end source codes. To do that,
  1) Install node.js in your computer.
  2) Open a command window and enter into the "{yoursolutionpath}/mimicore3.1/Frontend" directory.
  3) For the first time running, type "npm install" to install all necessary modules.
  4) Type "npm run fix" and press enter. This step is not mandatory, but if you make some changes in the future, then you can do that to lint your front end codes.
  5) Type "npm run build" and press enter.
  6) By the way, I use Visual Studio Code as the IDE for the front end coding, it is marvelous! I encourage you to use it as well. Don't forget to add the necessary extensions to facilitate your Vue coding!
2. Then you can run the app in Visual Studio 2019 in debug mode.

To login, you can enter any random text as the username, and simply copy it as the password, then you are in!

