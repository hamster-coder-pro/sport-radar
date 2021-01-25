## Sportradar - Coding Exercise

1. First of all, and I mentined this already - larger "test" exrsice with the requested features (code, test) + moch more addtional (dependecy injection, console bootstrap, configuration and etc., 100% code coverage) in located [**HERE**](https://github.com/hamster-coder-pro/searchfight/)
2. In my pactice I'm not using TDD, because by default it require test written before code. In the real life there are no money, time and business need to build application in such way.
3. However in case of big application with large probablity of regression verifications and sensitivity to production exceptions defenitely I have experince in writing Unit Tests with moqs / UI Tests with Selenium / Performance Tests and probably some mutations of them :)
4. Moreover even in this exercise starting writing the tests pushed me to write IGamesStorage interface to abstract working with games collection and be able to increase code coverage in critical part of the application (GamesManager)
5. Hard to "show the progress" in Git commits when task time in couple hours, but hopefully you will like the solution structure and code.

---

Code is written base on .net core 5.0 with nullable feature suport.

Tests created on NUnit framework + Moq + FluentAsserts

There is example of exception handling and exception wrapping.

To simplify solution - dependency injection, logging and multithreading, documentation not added.

Enjoy your review,

**Hamster Coder**