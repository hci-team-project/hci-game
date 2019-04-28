var canvas;
var mouseX = 150; // 쥐 좌표
var mouseY = 120;
var context;
var mouseImage = 'resource/mouse.png';
var width = 480;
var height = 270;
var background;

var delay = 10; // 제한 시간(초)
var timer;
var clock = delay;

var cur = 0;// 현재 문제 번호
var select; // 사용자가 누른 정답
var question = [
  '2 + 2 X 2',
  '골목을 뜻하는 제주도 사투리는?',
  '손오공, 저팔계, 사오정이 나오는 명나라 소설은?',
  '음력으로 매월 마지막 날 뜨는 달의 이름은?',
  '특정한 시각과 장소를 정해 하는 밀회를 뜻하는 프랑스어는?',
  '푸른 하늘 ㅇㅇㅇ 하얀 쪽배에',
  '캐나다의 수도는?',
  '다음 중 수도가 아닌 도시는?',
  '브라질의 관능적인 춤과 노래는?',
  '우주에 있는 온갖 사물과 현상은?',
];
var options = [
  '4/6/8',
  '올레/둘레/소담',
  '서유기/최유기/드래곤볼',
  '섣달/초승달/그믐달',
  '쥬뗌므/랑데부/쁘띠',
  '은하수/적란운/둥근달',
  '밴쿠버/토론토/오타와',
  '마드리드/시드니/델리',
  '람보/람보르기니/람바다',
  '아수라/삼라만상/만산천인'
];
var answer = [
  2, 1, 1, 3, 2, 1, 3, 2, 3, 2,
];

/********************
  기본 쥐 좌표 (150, 120)
  1번 좌표    (50, 120)
  2번 좌표    (150, 120)
  3번 좌표    (260, 120)
**********************/

var bgm;
var ticking;

var start = false;
var fail = false;


// 드래그
// var bb;
// var startX, startY;
// var iX, iY;
// var isDrag = false;
// var iTop = 20, iLeft = 20, iWidth = 100, iHeight = 100;


window.onload = function() {
  canvas = document.getElementById('canvas');
  context = canvas.getContext('2d');

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

  // canvas.addEventListener('mousemove', mousemove);
  // canvas.addEventListener('mousedown', mousedown);
  // canvas.addEventListener('mouseup', mouseup);
}

function startBtnClick() {
  if(!start) {
      start = true;
      init();
  }
}

function init() {
  // 초기화

  // 드래그
  // bb = canvas.getBoundingClientRect();
  // var image = new Image();
  // image.src = mouseImage;
  // context.drawImage(image, iLeft, iTop, 30, 30);
  // context.fillRect(iLeft, iTop, iWidth, iHeight);

  // 배경음악
  bgm = new Audio('resource/creepybgm.mp3');
  bgm.oncanplaythrough = function() {
    bgm.play();
  }

  // 시계
  ticking = new Audio('resource/ticking.mp3');

  // 배경 이미지
  background = 'resource/backimg.jpg';
  canvas.style.background = 'url('+background+')';
  canvas.style.backgroundSize = 'cover';

  drawMouse();
  drawQuestion();
}
//
// function mousedown(e) {
//   // 마우스 버튼 클릭 이벤트 핸들러
//   // 박스 위치이면 drag 를 시작한다.
//   startX = e.clientX - bb.left;
//   startY = e.clientY - bb.top;
//
//   if(startX > iLeft && startX < (iLeft + iWidth) && startY > iTop && startY < (iTop + iHeight)) {
//     isDrag = true;
//   }
// }
//
// // 마우스 이동 이벤트 핸들러
// // drag 중이면 박스를 이동한다.
// function mousemove(e) {
//  if(isDrag) {
//   iX = e.clientX - bb.left;
//   iY = e.clientY - bb.top;
//
//   console.log('iX iY', iX, iY);
//
//   draw();
//  }
// }
//
// // 박스를 그린다.
// function draw() {
//  context.clearRect(0, 0, canvas.width, canvas.height);
//  var image = new Image();
//  image.src = mouseImage;
//  context.drawImage(image, iLeft + iX - startX, iTop + iY - startY, 30, 30);
//  // context.fillRect(iLeft + iX - startX, iTop + iY - startY, iWidth, iHeight);
//
//
//  if(isDrag == false) {
//   iLeft = iLeft + iX - startX;
//   iTop = iTop + iY - startY;
//  }
// }
//
//
// // 마우스 버튼 클릭 해제 이벤트 핸들러
// // drag 중이면 박스의 최종 위치에 그려준다.
// function mouseup(e) {
//
//  if(isDrag) {
//   iX = e.clientX - bb.left;
//   iY = e.clientY - bb.top;
//
//   isDrag = false;
//   draw();
//  }
// }




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
  context.font = 'bold 10pt "맑은 고딕"';
  context.textAlign = 'left';
  context.fillStyle = 'rgba(255, 255, 255, 1)';
  context.fillText(str, 30, 30);
  // document.all.timeLeft.innerHTML=clock;

  // hideQuestion();

  // 보기 출력
  var op = options[cur].split('/');
  console.log('op');

  var point = [25, 120, 220];
  for(var i=0; i<3; i++) {
    context.textAlign = 'center';
    context.fillText(op[i], point[i]+30, 80);
  }
  // context.fillText(op[0], 25, 80);
  // context.fillText(op[1], 120, 80);
  // context.fillText(op[2], 210, 80);

  // 10초 세기 시작
  timer = setTimeout('timeover()', 10000);
  ticking.play();
}

function timeover() {
  // 시간 긑나벌임
  console.log('타임 오버');
  ticking.pause();
  clearTimeout(timer);
  select = 0;
  checkAnswer(select);
}

function hideQuestion() {
  // 시간 제한
  if (clock > 0) {
    document.all.timeLeft.innerHTML=clock;
    clock--;
    timer = setTimeout("hideQuestion()", 1000);
  } else {
    clearTimeout(timer);
    clock=delay;
    cur++;
    context.clearRect(0, 0, 480, 30);
    drawQuestion();
  }
}


function checkAnswer(select) {
  ticking.pause();
  clearTimeout(timer);

  if(answer[cur] == select) {
    // 정답
  }
  else {
    // 오답 - 게임 끝남
    fail = true;
    gameOver();
    return;
  }
  console.log('cur', cur);
  if(cur < 9) {
    cur++; // 다음 문제로~ ^^
    context.clearRect(0, 0, 480, 180);

    drawQuestion();
  }
  else {
    gameOver();
  }
}

function gameOver() {
  context.clearRect(0, 0, width, height);

  if(fail)
    background = 'resource/fail.jpg';
  else
    background = 'resource/success.png';

  canvas.style.background = 'url('+background+')';
  canvas.style.backgroundSize = 'cover';

  bgm.pause();
  ticking.pause();
}
