# LSW Interview

## Features and Technical Aspects

The game's movement system is a very standard implementation out of Unity's default input system. Dynamic objects (in this case, the player) constantly update their sprite render order, so that the illusion of depth is properly shown.

The animations are on the funky side, for sure, in order to minimize the time I would spend having to animate the sprites. I didn't want to use asset store/external sprites in order to give it a bit more personality. Outfits are dynamic and are changed based on skeletal animation sprite replacement, meaning it's scalable to a project with more complex animations.

Interaction with the world is implemented in a cost-efficient way, utilizing Unity's own trigger systems to minimize the amount of raycasts we would need to manually cast. Interaction priority is picked based on proximity.

The inventory system supports item stacking and can be reset by interacting with machine, in order to test things again. Inventories and items are already Scriptable Objects for more extensibility.

Events are created whenever possible, in order to keep the code decoupled and easy to extend.

I tend to always adapt my coding style to the house's, and on a whim I used the one I've been using recently in another project. So it's not that I'm particularly keen on making member variables explicit, I'm always adapting to whatever style is already in place.

## Shortcomings

The implemented features are extremely simple, but form the basis of a huge portion of games. The implementations themselves are something most developers are used to, so they aren't very difficult to program. However, the sheer amount of things to code in a small timeframe made the process a race against time. I didn't have that much time available these past 48 hours, so in the end I was a bit short on time. I couldn't refactor the code and pretty it up, as well as re-organize the Unity project and implement additional features I was interested in. The core features should be there, though, and should be following good practices. I also spent way too much time working on the sprites, even though it's a coding interview - I just thought it'd look more genuine and personal that way, hopefully it paid off.

## Conclusion 

It was a very fun project to work on! I'm pleased with the end result, and hope it will be well received to whoever is reading this. I thank you for your time analyzing my project, and am readily available in case any questions show up. 
