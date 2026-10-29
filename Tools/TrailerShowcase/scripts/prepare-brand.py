"""Copy and reskin the exact Shotcraft closing recipe; preserve its tuned curves."""
from pathlib import Path
import json

root = Path(__file__).resolve().parents[1]
skill = Path.home() / '.agents/skills/video-shotcraft'
dest = root / 'src/components'
motion = (skill / 'demos/_fixtures/Motion.tsx').read_text(encoding='utf-8')
# The recipe retains its 4.4-second motion arc inside the 5-second shot.
motion = motion.replace('const { durationInFrames } = useVideoConfig();', 'const durationInFrames = 264;')
(dest / 'Motion.tsx').write_text(motion, encoding='utf-8')
source = (skill / 'demos/outro/logo-shrink-wordmark-lockup/LogoShrinkWordmarkLockup.tsx').read_text(encoding='utf-8')
source = source.replace("'../../_fixtures/Motion'", "'./Motion'").replace("'../../_fixtures/Polish'", "'./Brand'").replace("'../../_fixtures/Brand'", "'./Brand'")
source = source.replace('const WORD_W = 172;', 'const WORD_W = 160;')
source = source.replace("const ACCENT = '#9d94ff';", "const ACCENT = '#5CC8FF';")
source = source.replace("'#06070c'", "'#14103F'").replace('#0d0f17 0%, #07080d 60%, #05060a 100%', '#221C5C 0%, #14103F 60%, #14103F 100%')
source = source.replace("{PITCH.en.motto.toUpperCase()}", "{PITCH.en.motto}")
(dest / 'LogoShrinkWordmarkLockup.tsx').write_text(source, encoding='utf-8')
cards = json.loads((skill / 'gallery/api/library.json').read_text(encoding='utf-8'))['cards']
card = next(c for c in cards if c['name'] == 'logo-shrink-wordmark-lockup')
(root / 'docs/shotcraft-card.json').write_text(json.dumps(card, ensure_ascii=False, indent=2), encoding='utf-8')
