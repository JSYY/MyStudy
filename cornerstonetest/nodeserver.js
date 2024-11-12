var express = require('express');
let fs = require('fs');
const path = require('path');

var app = express();
app.use(express.static('dist'));
app.get('/GetImage',function(req,res){
   let stream = fs.readFileSync(req.query.data);
   res.send(stream);
})

app.get('/GetDirectory',function(req,res){
   console.log(req.query.data);
   let dirpath = req.query.data;
   let fileNameList = fs.readdirSync(dirpath);
   let filelist = fileNameList.map(item=>path.join(dirpath,item));
   res.send(filelist);
});

app.listen(8888);

app.use(express.static('../dist'));
console.log('server is running, listening on 8888');
 


//字节截取的方式读取字节流
function readBinary(filename, callback) {
   var rstream = fs.createReadStream(filename);
   var chunks = [];
   var size = 0;
   rstream.on('readable', function() {
           var chunk = rstream.read();
           if (chunk != null) {
                   chunks.push(chunk);
                   size += chunk.length;
           }
   });
   rstream.on('end', function() {
           callback(null, Buffer.concat(chunks, size));
   });
   rstream.on('error', function(err) {
           callback(err, null);
   });
}
