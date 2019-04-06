var canvas;
var x = 150; // 쥐 좌표
var y = 120;
var context;
var mouseImage = "resource/mouse.png";
var audio;
var width = 480;
var height = 270;
var background;


/********************
  기본 쥐 좌표 (150, 120)
  1번 좌표    (50, 120)
  2번 좌표    (150, 120)
  3번 좌표    (260, 120)
**********************/

window.onload = function() {
  canvas = document.getElementById("canvas");
  context = canvas.getContext("2d");
  // audio = new Audio('resource/Creepy-music-box-twisted-lullaby.mp3');
  // audio.play();
  background = "resource/background.jpg";
  canvas.style.background = "url("+background+")";
  canvas.style.backgroundSize = "cover";

  draw();

}

function draw() {
  // 쥐 그리는 함수
  var image = new Image();
  image.src = mouseImage;
  // context.drawImage(image, 0, 0);
  image.onload = function() {
    context.drawImage(image, x, y, 30, 30);
  }
}
