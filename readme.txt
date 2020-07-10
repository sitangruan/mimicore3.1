Hello, mimicore3.1 is a .NET core web application. It is built in Visual Studio 2019 with .NET Core 3.1.

In this application it is using Vue as the front end framework to build a SPA (Single Page Application).

It is a mini app and the purpose is to demo the idea to adopt Vue in building a .NET core web SPA application, so it won't be complicated. I only implement it in a simple way. Don't complain if you feel some features are missing!

The backend is not the emphasis in this project, it behaves more like a simple REST API.

To run the app
1. First you need to compile the front end source codes. To do that,
  1) Install node.js in your computer.
  2) Open a command window and go to the {yoursolutionpath}/mimicore3.1/Frontend directory.
  3) For the first time running, type "npm install" to install all necessary modules.
  4) Type "npm run fix" and press enter. This step is not mandatory, but if you make some changes in the future, then you can do it to lint your front end codes.
  5) Type "npm run build" and press enter.
2. Then you can run the app in Visual Studio 2019 in debug mode

Secret: to login, you just need to ensure user name equal to password.

Please be aware, this is a SPA app, so the view files under Views folder are very simple, and it will be updated automatically when you build the front end source codes. You don't need to write any content into them. Indeed I will probably removed that from source codes, only keep the empty folders. And by that you will always have to remember to comiple the front end codes to able to run the app!

It demo these usages of Vue
1. Component creation
2. Transition for menu list animation
3. Axios for API calling
4. Vue-router for routing
5. Vuex to store the common state info like user's profile and his module permissions.