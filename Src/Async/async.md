# Async

Async的关键，就是为了：
* 并发
  * 本 project 中的例子就是 task 并发，同时进行
* non-blocking
  * 最经典的前端加载图片的例子，Async 同时加载图片和文字，文字会先加载出来，之后图片加载出来再显示出来
