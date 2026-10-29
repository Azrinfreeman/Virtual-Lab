"""Original 96 BPM score and restrained original editorial sound design, seed fixed."""
from pathlib import Path
import wave
import numpy as np
root=Path(__file__).resolve().parents[1]
out=root/'public/audio'
out.mkdir(parents=True,exist_ok=True)
rate=48000
def write(name,data):
    if data.ndim==1:data=np.column_stack([data,data])
    with wave.open(str(out/name),'wb') as w:
        w.setnchannels(2);w.setsampwidth(2);w.setframerate(rate)
        w.writeframes((np.clip(data,-.98,.98)*32767).astype('<i2').tobytes())
def hz(note):return 440*2**((note-69)/12)
t=np.arange(rate*60)/rate
beat=t/.625
song=np.zeros((len(t),2))
chords=[[50,57,62,65],[46,53,58,62],[53,60,65,69],[48,55,60,64]]
rng=np.random.default_rng(96)
for bar in range(24):
    start=bar*2.5; idx=(t>=start)&(t<start+2.5);u=t[idx]-start
    chord=chords[(bar//2)%4]
    env=np.minimum(1,u/.2)*np.minimum(1,(2.5-u)/.4)
    pad=sum(np.sin(2*np.pi*hz(n)*u)+.2*np.sin(2*np.pi*hz(n)*1.003*u) for n in chord)*.035*env
    song[idx,0]+=pad;song[idx,1]+=pad*.97
for b in range(96):
    start=b*.625;idx=(t>=start)&(t<start+.625);u=t[idx]-start
    chord=chords[(b//8)%4]
    energy=.35 if b<8 else (.45 if 32<=b<44 else (.85 if b<88 else .5))
    if b<92:
        kick=np.sin(2*np.pi*(48*u+2.2*(1-np.exp(-u*35))))*np.exp(-u*19)*.22*energy
        bass=np.sin(2*np.pi*hz(chord[0]-12)*u)*np.exp(-u*5)*.11*energy
        noise=rng.standard_normal(len(u));hat=np.diff(noise,prepend=noise[0])*np.exp(-u*85)*.014*energy
        snare=noise*np.exp(-u*24)*.035*energy if b%4 in (1,3) else 0
        drum=kick+bass+hat+snare
        song[idx,0]+=drum;song[idx,1]+=drum
    if b%2==0:
        n=chord[(b//2)%4]+12
        mallet=(np.sin(2*np.pi*hz(n)*u)+.18*np.sin(2*np.pi*hz(n)*2.01*u))*np.exp(-u*6)*.075
        song[idx,0]+=mallet;song[idx,1]+=mallet*.8
fade=np.minimum(1,t/1.2)*np.minimum(1,(60-t)/1.8)
song*=fade[:,None]
write('score-raw.wav',song)
u=np.arange(int(rate*1.5))/rate
noise=rng.standard_normal(len(u))
rise=np.convolve(noise,np.ones(20)/20,mode='same')*np.sin(np.pi*u/1.5)**2*.1
write('brand-rise.wav',rise)
u=np.arange(int(rate*1.7))/rate
land=(np.sin(2*np.pi*62*u)*np.exp(-u*7)+.2*np.sin(2*np.pi*784*u)*np.exp(-u*5))*.16
write('brand-land.wav',land)
print('Original score and two original closing sounds synthesized; fixed seed96.')
