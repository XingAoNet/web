function extractNodes(pNode){
	if(pNode.nodeType == 3)return null;
	var node,nodes = new Array();
	for(var i=0;node= pNode.childNodes[i];i++){
		if(node.nodeType == 1)nodes.push(node);
	}
	return nodes;
}
var obj=document.getElementById("rolltxt");
for(i=0;i<4;i++){
	obj.appendChild(extractNodes(obj)[i].cloneNode(true));
}
settime=0;
var t=setInterval(rolltxt,50);
function rolltxt(){
	if(obj.scrollTop % (obj.clientHeight) ==0){
		settime+=1;
		if(settime==50){
			obj.scrollTop+=1;
			settime=0;
		}
	}else{
		obj.scrollTop+=1;
		if(obj.scrollTop==(obj.scrollHeight-obj.clientHeight)){
			obj.scrollTop=0;
		}
	}
}
obj.onmouseover=function(){clearInterval(t)}
obj.onmouseout=function(){t=setInterval(rolltxt,50)}