node websocket-relay.js supersecret 18001 18002

ffmpeg -f dshow -i video="USB Camera" -q 0 -f mpegts -vcodec mpeg1video -r 16 -s 800x600 http://127.0.0.1:18001/supersecret

-r 表示帧率

-vf表示设置视频的旋转 vflip表示垂直翻转  hflip表示水平翻转