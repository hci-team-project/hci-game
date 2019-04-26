var canvas;
var mouseX = 150; // 쥐 좌표
var mouseY = 120;
var context;
var mouseImage = 'resource/mouse.png';
var audio;
var width = 480;
var height = 270;
var background;

var delay = 10; // 제한 시간(초)
var timer;
var clock = delay;

var cur = 0;// 현재 문제 번호
// var answer; // 문제의 정답
var select; // 사용자가 누른 정답

var question = [
  '1번 문제',
  '2번 문제',
  '3번 문제',
  '4번 문제',
  '5번 문제',
  '6번 문제',
  '7번 문제',
  '8번 문제',
  '9번 문제',
  '10번 문제',
];
var answer = [
  1, 2, 3, 1, 2, 3, 1, 2, 3, 1
];

/********************
  기본 쥐 좌표 (150, 120)
  1번 좌표    (50, 120)
  2번 좌표    (150, 120)
  3번 좌표    (260, 120)
**********************/

window.onload = function() {
  canvas = document.getElementById('canvas');
  context = canvas.getContext('2d');
  // audio = new Audio('resource/Creepy-music-box-twisted-lullaby.mp3');
  // audio.play();
  background = 'resource/backimg.jpg';
  canvas.style.background = 'url('+background+')';
  canvas.style.backgroundSize = 'cover';

  drawMouse();
  drawQuestion();

  canvas.addEventListener('click', function(e) {
    // 클릭한 좌표 알아내기
    var x = e.layerX;
    var y = e.layerY;
    console.log({x: e.layerX, y: e.layerY});

    /* 정답 영역 범위
       1번 : x: 30 ~ 170, y: 65 ~ 180
       2번 : x: 190 ~ 330
       3번 : x: 360 ~ 480
    */

    if(x >= 30 && x <= 170 && y >= 65 && y <= 180) {
      // 1번 클릭
      select = 1;
      console.log('1번');
    }
    else if(x >= 190 && x <= 330 && y >= 65 && y <= 180) {
      // 2번 클릭
      select = 2;
      console.log('2번');
    }
    else if(x >= 360 && x <= 480 && y >= 65 && y <= 180) {
      // 3번 클릭
      select = 3;
      console.log('3번');
    }

    checkAnswer(select);  // 답 확인하러 ㄱㄱ

  });
}

function drawMouse() {
  // 쥐 그리는 함수
  var image = new Image();
  image.src = mouseImage;
  // context.drawImage(image, 0, 0);
  image.onload = function() {
    context.drawImage(image, mouseX, mouseY, 30, 30);
  }
}

function drawQuestion() {
  // 문제 출력
  var str = `${cur+1}. ${question[cur]}`;
  context.font = 'bold 20pt "맑은 고딕"';
  context.fillStyle = 'rgba(255, 255, 255, 1)';
  context.fillText(str, 30, 30);
  document.all.timeLeft.innerHTML=clock;
  hideQuestion();
}

function hideQuestion(){
  // 시간 제한
  if (clock>0) {
    document.all.timeLeft.innerHTML=clock;
    clock--;
    timer=setTimeout("hideQuestion()",1000);
  } else {
    clearTimeout(timer);
    clock=delay;
    cur++;
    context.clearRect(0, 0, 480, 30);
    drawQuestion();
  }
}


function checkAnswer(select) {
  if(answer[cur] == select) {
    // 정답
  }
  else {
    // 오답
  }
  console.log('cur', cur);
  if(cur < 10) {
    cur++; // 다음 문제로~ ^^
    context.clearRect(0, 0, 480, 30);
    drawQuestion();
  }

}
