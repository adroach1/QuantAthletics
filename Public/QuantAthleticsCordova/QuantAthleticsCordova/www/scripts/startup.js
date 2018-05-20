define(["require", "exports", "./application"], function (require, exports, Application) {
    "use strict";
    // Try and load platform-specific code from the /merges folder.
    // More info at http://taco.visualstudio.com/en-us/docs/configure-app/#Content.
    require(["./platformOverrides"], function () { return Application.initialize(); }, function () { return Application.initialize(); });
});
//# sourceMappingURL=startup.js.map