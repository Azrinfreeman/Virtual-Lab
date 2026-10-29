from pathlib import Path
import base64
root=Path(__file__).resolve().parents[1]
project=root.parents[1]
def image(p):
    return 'data:image/png;base64,'+base64.b64encode(p.read_bytes()).decode()
lab=image(project/'Temp/TrailerShowcase/current-lab.png')
logo=image(root/'public/brand/logo.png')
page='''<!doctype html><html><head><meta charset="utf-8"><style>
body{margin:0;font-family:Arial;color:#F4F2FF} .frame{position:relative;aspect-ratio:16/9;background:#14103F;margin-bottom:20px;overflow:hidden}
.frame img.game{width:87.5%;height:87.5%;object-fit:contain;margin:0 6.25%}.caption{position:absolute;bottom:3.5%;left:0;right:0;text-align:center;font-size:clamp(14px,2.2vw,42px)}
.end{display:flex;align-items:center;justify-content:center;flex-direction:column;background:radial-gradient(ellipse at top,#221C5C,#14103F)}
.lock{display:flex;align-items:center;gap:22px}.logo{width:100px}.name{font-size:64px}.motto{font-size:30px;color:#5CC8FF;margin-top:28px}
</style></head><body>'''
page+=f'<div class="frame"><img class="game" src="{lab}"><div class="caption">Terokai nutrisi dalam makmal maya.</div></div>'
page+=f'<div class="frame end"><div class="lock"><img class="logo" src="{logo}"><span class="name">BioNutri-MM</span></div><div class="motto">Belajar. Eksperimen. Fahami.</div></div></body></html>'
(root/'docs/styleframes.html').write_text(page,encoding='utf-8')
