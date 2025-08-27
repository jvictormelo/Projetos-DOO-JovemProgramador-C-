var contador = 0;

document.getElementById("botaoPrincipal").addEventListener("click",function(){
    alert("Você clicou no botão principal!");
   
});

document.getElementById("botaoContador").addEventListener("click",function(){
    contador++;
    document.getElementById("teste").textContent = contador;
});