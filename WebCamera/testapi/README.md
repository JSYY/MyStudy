node websocket-relay.js supersecret 18001 18002

ffmpeg -f dshow -i video="HJ 8M USB 2.0 Camera" -vf "vflip" -q 0 -f mpegts -vcodec mpeg1video -r 30 -s 800x600 http://127.0.0.1:18001/supersecret

-r ��ʾ֡��

-vf��ʾ������Ƶ����ת vflip��ʾ��ֱ��ת  hflip��ʾˮƽ��ת

ö���豸
ffmpeg -list_devices true -f dshow -i dummy