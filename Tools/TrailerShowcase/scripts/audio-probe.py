"""Measure this renderer/AAC/48kHz/MP4 pipeline; never borrow old offset constants."""
from pathlib import Path
import subprocess,json
import numpy as np
root=Path(__file__).resolve().parents[1]
def audio(path):
    r=subprocess.run(['ffmpeg','-v','error','-i',str(path),'-f','f32le','-ac','1','-ar','48000','-'],capture_output=True,check=True)
    return np.frombuffer(r.stdout,dtype='<f4')
source=audio(root/'public/audio/game-click.mp3')
render=audio(root/'out/qa/quiz-sfx-draft.mp4')
measure=[]
for target in [90,150,210]:
    expected=round(target/60*48000)
    lo=expected-6000;hi=expected+len(source)+6000
    window=render[lo:hi]
    correlations=np.correlate(window,source,mode='valid')
    lag=int(np.argmax(correlations))+lo-expected
    measure.append({'targetFrame':target,'onsetOffsetSamples':lag,'onsetOffsetFrames':lag/800,'peakOffsetFrames':lag/800+int(np.argmax(abs(source)))/800})
report={'pipeline':{'remotion':'4.0.539','codec':'AAC','sampleRate':48000,'container':'MP4','fps':60},'probes':measure,'sourcePeakLagFrames':int(np.argmax(abs(source)))/800,'sourceDurationSeconds':len(source)/48000,'maxPeakOffsetFrames':max(abs(x['peakOffsetFrames']) for x in measure),'status':'PASS' if max(abs(x['peakOffsetFrames']) for x in measure)<=.5 else 'REQUIRES_COMPENSATION'}
(root/'docs/audio-offset-probe.json').write_text(json.dumps(report,indent=2))
print(json.dumps(report,indent=2))
