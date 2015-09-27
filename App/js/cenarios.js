/**
 *	Mapa interativo, desenvolvido por Cherobin & Cherobin LTDA
  *	@author Ricardo Cherobin
 */
 
var width = window.innerWidth; 
var height = window.innerHeight;

window.onerror = function(error) {
	alert(error.toString());
};


var pontosMapa = new Array();
var informacaoesPontosMapa = new Array();
var mapas = new Array();

var J = jQuery.noConflict();

 

 J(function(){
	// esconder elementos iniciais

	J("#janela_alert").hide();
	J("#janela_modal").hide();
	J("#janela_modal2").hide();
	});

document.documentElement.style.overflow = 'hidden'; 
document.body.scroll = "no"; 
	
// Initialize canvas
var canvas = document.getElementById("canvas");

// Initialize context
var context = canvas.getContext('2d');

// Initialize listeners
var touchAvailable = ('createTouch' in document) || ('ontouchstart' in window);
if(touchAvailable) {
	canvas.addEventListener("touchend", touchUp, false);
	canvas.addEventListener("touchstart", touchDown, false);
	canvas.addEventListener("touchmove", touchMove, true);
} else {
	canvas.addEventListener("mouseup", mouseUp, false);
	canvas.addEventListener("mousedown", mouseDown, false);
	canvas.addEventListener("mousemove", mouseMove, false);
}

  

// Background
var background = new Image();
var backgroundX = 0;
var backgroundY = 0;
var backgroundW = 0;
var backgroundH = 0;
var imagesLoaded = 0;
 


var fps = 0;
var frame = 0;
var thisloop = 0;
var lastloop = new Date().getTime();
var thisSecond = (lastloop / 1000);
var lastSecond = 0;
var timeDifference = 0;

// Scroll
var mouseX = 0;
var mouseY = 0;
var touchX = 0;
var touchY = 0;
var touches = 0;
var drag = false;
 

// Buttons
var buttonsArray = new Array();
var buttonSelected = null;
var sceneId = "";
var mapaInicial = 0;
function init(){

  
	setTimeout(function(){	
		load(background, "http://54.232.244.189/imagens/cenarios/primeiro_andar.gif");
  	
		 
		
		 
		 
	 
	 
	}, 1);
	
	setTimeout(function(){	
		 loadPontos(1) ;
	 
	 
	}, 5);


	 
	setTimeout(function(){
		resize();
		gameLoop();
	}, 2000);


	 
	 
}

	

 
var a =1;
function gameLoop() {
	if(window.innerWidth != width || window.innerHeight != height){
		resize();
	}
	thisloop = new Date().getTime();
	timeDifference = (thisloop - lastloop);
	lastloop = thisloop;
	lastSecond = Math.floor(thisloop / 1000);
	if(lastSecond != thisSecond){
		fps = frame;
		frame = 1;
		thisSecond = lastSecond;
		
	} else {
		frame ++;
	}
	//;update(timeDifference);
	 
 
			draw();
	 
	setTimeout(gameLoop, 5);
}

//function update(timeDifference) {}

function draw(){
	clear();
	 
	// Draw background
	if(background != null && imagesLoaded>0) {
		resizeBackground();
		context.drawImage(background, backgroundX, backgroundY, backgroundW, backgroundH);
		drawButtons();
		//imagesLoaded= 0;
	}  
	
	
	
	 
	
	
 
 
}

function drawButtons() {
 
	if(buttonsArray != null) {
		for (var i = 0; i < buttonsArray.length; i++) {
		
				var x = (buttonsArray[i].x * backgroundW / background.width) + backgroundX;
				
				if(buttonsArray[i].type==0)
					x = buttonsArray[i].x;
					
				if(width <= background.width) {
					if(buttonsArray[i].type!=0)
						x = buttonsArray[i].x + backgroundX;
				}
				
				var y = (buttonsArray[i].y * backgroundH / background.height) + backgroundY;
				
				if(buttonsArray[i].type==0)
					y = buttonsArray[i].y;
					
				if(height <= background.height && width <= background.width) {
					if(buttonsArray[i].type!=0)
						y = buttonsArray[i].y + backgroundY;
				}

				var w = buttonsArray[i].w;
				var h = buttonsArray[i].y;
				if(buttonsArray[i].type!=0)
					if(height <= background.height && width <= background.width) {
						w = buttonsArray[i].w;
						h = buttonsArray[i].h;
					} else {
						w = buttonsArray[i].w * width / background.width;
						h = buttonsArray[i].h * width / background.height;
					}
					
				buttonsArray[i].propX = x;
				buttonsArray[i].propY = y;
				buttonsArray[i].propW = w;
				buttonsArray[i].propH = h;
			
		
		if(buttonsArray[i].type ==1){
		
			if(buttonsArray[i].imgButton.getAttribute("src")===null){
				 buttonsArray[i].imgButton.src = buttonsArray[i].src;	
				 buttonsArray[i].w =buttonsArray[i].imgButton.naturalWidth/2;
				 buttonsArray[i].h = buttonsArray[i].imgButton.naturalHeight/2;				 				 
			}else{
				  context.drawImage(buttonsArray[i].imgButton, x, y, buttonsArray[i].w, buttonsArray[i].h);
				   //console.log("xxxxxxxxxxx "+buttonsArray[i].imgButton.src);	
				 					  
				 }
			 }
			 else{
			 context.fillStyle = "rgba(0, 0, 0, 50)";
			 context.fillRect(x, y, w, h);
			//  console.log("fillRect");
			 }
		//console.log("fillRect"+buttonsArray[i].src);
		
			 
		}
	}

}

 

function resize() {
	backgroundX = 0;
	backgroundY = 0;
	width = window.innerWidth;
	height = window.innerHeight;
	canvas.width = width;
	canvas.height = height;
	draw();
}

function clear() {
  context.fillStyle = '#000000';
  context.clearRect(0, 0, width, height);
  context.beginPath();
  context.rect(0, 0, width, height);
  context.closePath();
  context.fill();
}

function resizeBackground() {
	var distanceX = width - background.width;
	var distanceY = height - background.height;
	if(distanceX > distanceY) {
		scale = distanceX;
	} else {
		scale = distanceY;
	}
	if(scale < 0) {
		scale = 0;
	}
	backgroundW = (background.width + scale);
	backgroundH = (background.height + scale);
}

function mouseUp(e) {
	drag = false;
	for(var i = 0; i < buttonsArray.length; i++) {
		if(buttonOver(mouseX, mouseY, buttonsArray[i])) {
			if(buttonSelected != null) {
				
					setBackground(buttonsArray[i].id);
					//window.location = "cenarios.html+" + buttonsArray[i].target;
				
				return;
			}
		}
	}
}

function mouseDown(e) {
	e.preventDefault();
	for(var i = 0; i < buttonsArray.length; i++) {
		if(buttonOver(mouseX, mouseY, buttonsArray[i])) {
			if(buttonSelected == null) {
				buttonSelected = buttonsArray[i];
				drag = true;
				return;
			}
		}
    }
	buttonSelected = null;
	drag = true;
}

function mouseMove(e) {
	e.preventDefault();
	var oldX = mouseX;
	var oldY = mouseY;
    mouseX = (e.pageX - canvas.offsetLeft);
    mouseY = (e.pageY - canvas.offsetTop);
	if(drag) {
		backgroundX += (mouseX - oldX);
		backgroundY += (mouseY - oldY);
	}
	limitMove();
}

function touchUp(e) {
	touches = e.targetTouches.length;	 
	drag = false;
	for(var i = 0; i < buttonsArray.length; i++) {
		if(buttonOver(touchX, touchY, buttonsArray[i])) {
			if(buttonSelected != null) {
			
				setBackground(buttonsArray[i].id);
				
				return;
			}
		}
	}
}

function touchDown(e) {
	e.preventDefault();
	touches = e.targetTouches.length;
	touchX = e.targetTouches[0].pageX - canvas.offsetLeft;
	touchY = e.targetTouches[0].pageY - canvas.offsetTop;
	for(var i = 0; i < buttonsArray.length; i++) {
		if(buttonOver(touchX, touchY, buttonsArray[i])) {
			if(buttonSelected == null) {
				buttonSelected = buttonsArray[i];
				drag = true;
				return;
			}
		}
    }
	drag = true;
}

function touchMove(e) {
	e.preventDefault();
	var oldX = touchX;
	var oldY = touchY;
	touchX = e.targetTouches[0].pageX - canvas.offsetLeft;
	touchY = e.targetTouches[0].pageY - canvas.offsetTop;
	if(drag){
		backgroundX += (touchX - oldX);
		backgroundY += (touchY - oldY);
	}
	limitMove();
}

function limitMove() {
	if(backgroundX > 0) {
		backgroundX = 0;
	}
	if(backgroundX < (-backgroundW) + width) {
		backgroundX = (-backgroundW) + width;
	}
	if(backgroundY > 0) {
		backgroundY = 0;
	}
	if(backgroundY < (-backgroundH) + height) {
		backgroundY = (-backgroundH) + height;
	}
}

 
function setBackground(id) {
	
	backgroundX = 0;
	backgroundY = 0;
		
		
		//console.log("aaa");
	loadInformacaoPontos(id)
 
	
}

function Button() {
	this.id = "Cidade";
	this.x = 0;
	this.y = 0;
	this.propX = 10;
	this.propY = 10;
	this.w = 100;
	this.h = 1000;
	this.propW = 100;
	this.propH = 100;
	this.fill = '#444444';
	this.target = "Cidade";
	this.type = 0;
	this.imgButton= new Image();
}

function addButton(id, x, y, w, h, fill, target, type, src) {
	var rect = new Button;
	 console.log("addButton"+src );
	var imgButton = new Image();
	
	rect.src = src;
	rect.id = id;
	rect.type = type;
	rect.x = x;
	rect.y = y;
	rect.w = w;
	rect.h = h;
	rect.target = target;
	
	console.log(rect);
    buttonsArray.push(rect);
		 
					
	
	 
}

function buttonOver(targetX, targetY, bt) {
	var x = bt.propX;
	var y = bt.propY;
	if(targetX >= x && targetX <= (x + bt.propW) && targetY >= y && targetY <= (y + bt.propH)) {
		return true;
	} else {
		return false;
	}
}

 

function load(img, src) {
	if(img.src == "") {
		img.src = src;
		img.onload = function () {
			imagesLoaded ++;
			console.log ("load img "+ img.src);
	 
		 
		}
	}
}


 
	function showModal2(textoFechar, home, logo, qrcode){
		
		
 
		 J("#janela_modal2 #janela_modal_fechar2").off();
    
    	J("#janela_modal2 #janela_modal_conteudo_home").html(home);
		J("#janela_modal2 #janela_modal_conteudo_logo").attr("src","http://54.232.244.189/"+logo);
		J("#janela_modal2 #janela_modal_conteudo_qrcode").attr("src","http://54.232.244.189/"+qrcode);
		
		J("#janela_modal2 #janela_modal_fechar2").html("Fechar");
    	J("#janela_modal2 #janela_modal_fechar2").on("click", function(){});
    		 
		
 
 
    	 J("#janela_modal2").modal('show');
		  // J("#janela_modal2").draggable();
		   
 

		// J( "#janela_modal2" ).dialog();
		
	}
 

	
	

function loadPontos(id){
 
	 buttonsArray = buttonsArray.splice(0, buttonsArray.lenght);
 
							
	 	J.ajax({
	        url: "http://54.232.244.189/company/list/json",
	     
	        type: 'GET',
	        context: document.body,
	        success: function(akira){
	       
	         var pontosEcontrado = jQuery.parseJSON(akira);
	 					   		
				console.log("##########loadPontos##########");

	     
	           		
		            for(var index in pontosEcontrado) { 
					   if (pontosEcontrado.hasOwnProperty(index)) {
					   		
					   		var pontoMapa = new PontoMapa();
					   	 
					   		pontoMapa.id = pontosEcontrado[index].id; 
					   		pontoMapa.logo = pontosEcontrado[index].logo;
					   		pontoMapa.posX = pontosEcontrado[index].posX;
					   	 	pontoMapa.posY = pontosEcontrado[index].posY;
					 
							
							addButton(pontoMapa.id ,parseInt(pontoMapa.posX), parseInt(pontoMapa.posY), 50, 20, "#000",pontoMapa.id ,1,"http://54.232.244.189/"+ pontoMapa.logo);
 
						  	self.pontosMapa.push(pontoMapa);
													
					 
					  }
					}
	           		
	             
	         }
		});
	}
	
	
	
function loadInformacaoPontos(id){
 	
  
		J.ajax({
	        url: "http://54.232.244.189/company/"+id+"list/json",
	       
	        type: 'GET',
	        context: document.body,
	        success: function(akira){
	        
	         var informacaoesEcontrado = jQuery.parseJSON(akira);
	 	  
					   		var informacaoPonto = new InformacaoPonto();
					   	 
					   		informacaoPonto.name = informacaoesEcontrado.name;
					   		informacaoPonto.id = informacaoesEcontrado.id;
							informacaoPonto.logo = informacaoesEcontrado.logo;
							informacaoPonto.qrcode = informacaoesEcontrado.qrcode;
							informacaoPonto.link = informacaoesEcontrado.link; 
							informacaoPonto.description = informacaoesEcontrado.description;
						  	
							self.informacaoesPontosMapa.push(informacaoPonto);		
 
							
							 showModal2(informacaoPonto.link, informacaoPonto.description,informacaoPonto.logo , informacaoPonto.qrcode);
							
				
				 
					   
				 
	         }
		});
		
	}


function loadMapas(id){
 
 var mapa = new Mapa();
							
							 
	 	
		
							mapa.mapa_id = "1";
					   		mapa.descricao = "aaa";
					   		mapa.endereco_arquivo = "http://127.0.0.1:8081/mesa_interativa/imagens/cenarios/primeiro_andar.gif"; 							
							 
						 				 
							mapa.endereco_arquivo_miniatura =  "http://127.0.0.1:8081/mesa_interativa/imagens/cenarios/primeiro_andar.gif";
							self.mapas.push(mapa);	
							
		/*J.ajax({
	        url: "load_mapas.php",
	        data: "idMapa="+id,
	        type: 'POST',
	        context: document.body,
	        success: function(akira){
	        
	         var mapasEcontrado = jQuery.parseJSON(akira);
	 					   		
				//console.log("##########loadMapas##########");

	           	if (mapasEcontrado.status != "none"){
	           		
		            for(var index in mapasEcontrado) { 
					   if (mapasEcontrado.hasOwnProperty(index)) {
					   		
					   		var mapa = new Mapa();
			

							mapa.mapa_id = mapasEcontrado[index].mapa_id;
					   		mapa.descricao = mapasEcontrado[index].descricao;
					   		mapa.endereco_arquivo = mapasEcontrado[index].endereco_arquivo; 							
							mapa.localizacao_horizontal = mapasEcontrado[index].localizacao_horizontal; 
							mapa.localizacao_vertical = mapasEcontrado[index].localizacao_vertical; 				 
							mapa.endereco_arquivo_miniatura =  mapasEcontrado[index].endereco_arquivo_miniatura;
							self.mapas.push(mapa);	
							
							console.log("#mapa "+mapas[0]["mapa_id"]);
							console.log("#mapa "+mapas[0]["descricao"]);
							console.log("#mapa "+mapas[0]["endereco_arquivo"]);
							console.log("#mapa "+mapas[0]["localizacao_horizontal"]); 
							console.log("#mapa "+mapas[0]["localizacao_vertical"]); 
							console.log("#mapa "+mapas[0]["endereco_arquivo_miniatura"]); 
						
							
					  }
					}
	           		
	            }   
	         }
		});
		
		 */
		  

	
	
	}
	
function PontoMapa(){
	this.id;
	this.name;
	this.logo;	 
	this.posX;
	this.posY;
	this.img = new Image();
}

function InformacaoPonto(){
	this.id;
	this.name; 	  
	this.description;
	this.logo;
	this.link;
	this.qrcode;
	
}


function Mapa(){
	this.mapa_id;
	this.descricao;
	this.endereco_arquivo;
 
	this.endereco_arquivo_miniatura;
	this.img = new Image();
 
 
}
 
  
 
 
document.addEventListener("deviceready", init);
window.addEventListener("load", init);
