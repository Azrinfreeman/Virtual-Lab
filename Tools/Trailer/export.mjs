import fs from 'node:fs';
import {spawnSync} from 'node:child_process';
// Reproducible edit. Set FFMPEG to an encoder path if it is not on PATH.
const ffmpeg=process.env.FFMPEG || 'ffmpeg';
const output='Deliverables/Trailer';
fs.mkdirSync(output,{recursive:true});
const rate=48000, samples=60*rate;
const audio=Buffer.alloc(44+samples*4);
audio.write('RIFF');audio.writeUInt32LE(audio.length-8,4);audio.write('WAVEfmt ',8);
audio.writeUInt32LE(16,16);audio.writeUInt16LE(1,20);audio.writeUInt16LE(2,22);
audio.writeUInt32LE(rate,24);audio.writeUInt32LE(rate*4,28);audio.writeUInt16LE(4,32);audio.writeUInt16LE(16,34);
audio.write('data',36);audio.writeUInt32LE(samples*4,40);
// Original synthesized instrumental, generated for this trailer; no third-party track.
const chords=[[48,55,60,64],[45,52,57,60],[41,48,53,57],[43,50,55,59]];
const hz=n=>440*2**((n-69)/12);
for(let i=0;i<samples;i++){
 const t=i/rate, beat=t/0.625, c=chords[Math.floor(beat/4)%4];
 const fade=Math.min(1,t/2,(60-t)/3), pulse=beat%1;
 let pad=0;for(const n of c)pad+=Math.sin(2*Math.PI*hz(n)*t)*0.018;
 const pluck=Math.sin(2*Math.PI*hz(c[Math.floor(beat*2)%4]+12)*t)*Math.exp(-((beat*2)%1)*6)*0.075;
 const bass=Math.sin(2*Math.PI*hz(c[0]-12)*t)*Math.exp(-pulse*5)*0.055;
 const kick=Math.sin(2*Math.PI*(42*t+7*(1-Math.exp(-pulse*14))))*Math.exp(-pulse*20)*0.035;
 const v=Math.tanh((pad+pluck+bass+kick)*fade);
 for(let channel=0;channel<2;channel++)audio.writeInt16LE(Math.round(v*(channel===0?1:0.96)*32767),44+i*4+channel*2);
}
fs.writeFileSync(`${output}/original-score.wav`,audio);
const captions=[
 [0,4,'Terokai sains melalui pengalaman'],[4,9,'8 aktiviti pembelajaran interaktif'],
 [9,20,'Kendalikan eksperimen dalam makmal 3D'],
 [20,29,'Perhati perubahan. Fahami tindak balas.'],
 [29,36,'Bandingkan kandungan vitamin C'],
 [36,43,'Kenali tubuh. Amalkan pemakanan sihat.'],
 [43,49,'Bantuan pembelajaran - demo luar talian'],
 [49,55,'Uji kefahaman anda'],[55,60,'BioNutri-MM  |  Belajar. Eksperimen. Fahami.']
];
const font="fontfile='Assets/TextMesh Pro/Fonts/LiberationSans.ttf'";
let filters=["scale=1700:956:flags=lanczos,pad=1920:1080:110:0:color=0x08081d,setsar=1"];
for(const [start,end,text]of captions){
 const p=`${output}/caption-${start}.txt`;fs.writeFileSync(p,text);
 filters.push(`drawtext=${font}:textfile='${p}':fontcolor=0xb3f2ff:fontsize=36:x=(w-text_w)/2:y=1003:enable='gte(t,${start})*lt(t,${end})'`);
}
fs.writeFileSync(`${output}/timing.txt`,'Rakaman animasi permainan; masa menunggu dipendekkan');
filters.push(`drawtext=${font}:textfile='${output}/timing.txt':fontcolor=white:fontsize=23:box=1:boxcolor=0x08081dcc:boxborderw=10:x=145:y=28:enable='gte(t,9)*lt(t,36)'`);
fs.writeFileSync(`${output}/demo.txt`,'DEMO LUAR TALIAN - jawapan contoh');
filters.push(`drawtext=${font}:textfile='${output}/demo.txt':fontcolor=0xb3f2ff:fontsize=26:box=1:boxcolor=0x08081dee:boxborderw=12:x=145:y=28:enable='gte(t,43)*lt(t,49)'`);
const edit = '[0:v]'+filters.join(',')+'[base];'+
 "movie='Assets/Scenes/nutrilogo.png',scale=170:170[logo];"+
 "[base][logo]overlay=x=1600:y=60:enable='gte(t,55)',fade=t=in:st=0:d=0.4,fade=t=out:st=59.3:d=0.7[vout]";
fs.writeFileSync(`${output}/edit-filter.txt`,edit);
const args=['-y','-hide_banner','-framerate','30','-start_number','0','-i','Temp/Trailer/frames/%05d.jpg',
 '-i',`${output}/original-score.wav`,'-filter_complex_script',`${output}/edit-filter.txt`,'-map','[vout]','-map','1:a:0',
 '-c:v','libx264','-preset','medium','-crf','19','-pix_fmt','yuv420p',
 '-af','volume=2.5','-c:a','aac','-b:a','192k','-ar','48000','-t','60','-frames:v','1800','-movflags','+faststart',
 `${output}/BioNutri-MM_Gameplay_Trailer_60s.mp4`];
const r=spawnSync(ffmpeg,args,{stdio:'inherit'});if(r.status!==0)process.exit(r.status||1);
spawnSync(ffmpeg,['-y','-hide_banner','-ss','12','-i',`${output}/BioNutri-MM_Gameplay_Trailer_60s.mp4`,'-frames:v','1',`${output}/thumbnail.jpg`],{stdio:'inherit'});
console.log('Exported 60-second trailer and thumbnail.');
