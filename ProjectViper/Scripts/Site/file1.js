// Type script test
var el = this.document.getElementById("content");
var User = (function () {
    function User(_name, _age) {
        this.name = _name;
        this.age = _age;
    }
    return User;
}());
var tom = new User("Tom", 29);
el.innerHTML = "Name: " + tom.name + "age: " + tom.age;
//# sourceMappingURL=file1.js.map