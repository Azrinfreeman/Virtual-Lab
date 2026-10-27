# UI refinement results

## Delivered

- Activity selection uses an aligned two-column, four-row grid with readable topic subtitles. Existing science artwork, colours, fonts, gradient buttons, animation containers, names, and click events remain in use. Directional keyboard navigation follows the grid.
- Screen canvases using the 1920×1080 reference now use Expand scaling, fitting the design within alternate aspect ratios. Constant-pixel-size/world apparatus label settings were not intentionally modified.
- Sixteen form/reading scenes now clamp vertical-only scrolling and use consistent wheel sensitivity. TMP input text and placeholders no longer intercept their containing field's pointer events.
- Existing HANTAR/Next controls positioned at the bottom edge are lifted by 32 reference units.
- Answer drags released outside an ItemSlot return to their original position and sibling order, restoring opacity and raycasts.
- Lab apparatus dragging cannot start from a pointer press over blocking UI.
- Scene navigation ignores repeated transition clicks. Existing button hover animations also respond to keyboard selection, and confirmation effects do not start duplicate coroutines.
- Editor-only preview utilities in `Assets/Editor/BioNutriUIReview.cs` allow repeatable captures without changing the user's active scene. Preview rendering uses a temporary camera and is not a runtime screenshot or a full laboratory simulation.

## Verification performed

- Inspected activity menu captures at 1920×1080, 1366×768, 1280×720, 1024×768, 1920×1200, and 2560×1080. Existing branding remains; all eight activity buttons fit.
- Inspected worksheet and Healthy Plate previews at 1366×768. Lab preview does not reproduce the animated runtime camera and is not used to claim laboratory visual acceptance.
- Executed an isolated Unity check using the actual DragScript: invalid release restores its source position and raycast state.
- Unity compiled the changes. Final console query returned no error entries at that point.
- No build, publication, account changes, or backend deployment performed.

## Limits and next verification

This is the first UI refinement pass, not completion of every proposed screen-specific improvement. Full Play Mode walks through experiment animations, accepted drops, nested scroll areas, keyboard focus, replay, dialogs, and online score/chat states are still required. No broad dialog rewrite, automatic answer hints, new palette, artwork replacement, or unverified authentication changes were introduced. Login, score-review, chatbot placement, and modal-flow redesign remain candidates for a subsequent inspected pass.

The workspace already had many unrelated modifications. Preserve them when reviewing or committing this work. Captures here show edit-time UI previews; invisible panels and runtime-only states require separate inspection.

## Captures

- `activities-before.png`: original single-column activity menu.
- `activities-after.png`: revised activity grid at 1920×1080.
- `menu-1024.png`: 4:3 preview.
- `menu-2560.png`: ultrawide preview.
- `worksheet-after.png`: worksheet after spacing/scroll changes.
