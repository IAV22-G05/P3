# INTELIGENCIA ARTIFICIAL PARA VIDEOJUEGOS - PRÁCTICA 3 - GRUPO 05

Sergio Molinero Aparicio - Andrés Carnicero Esteban

Video: https://youtu.be/5Xs9pihlOtY

Resumen de objetivos.

## RESUMEN
Esta práctica se basa en el Fantasma de la Ópera.

El prototipo consistirá en recrear un escenario con distintos espacios o salas que simulen la Ópera, con su escenario, butacas, sótanos, palcos...

En este escenario estarán varios personajes, el fantasma, que descansará en su sótano y su objetivo será capturar al segundo personaje, la cantante, después tendremos al vizconde,
el encargado de salvar a la cantante en caso de que la rapte o se pierda por el escenario y el público que huirá despavorido por los actos del fantasma.

### Diagrama del escenario
Aquí se muestra un resumen del escenario en forma de diagrama..
![Diagrama Opera](https://github.com/IAV22-G05/P3/blob/main/Assets/Imagenes/DIAGRAMA%20OPERA.jpg)

### Explicación comportamientos personajes
Como hemos mencionado antes, tendremos varios personajes, 3 serán agentes inteligentes y otro el jugador.

#### Comportamiento Fantasma
Su estancia incicial es la sala de música.

Su objetivo principal es secuestrar a la cantante, buscando principalmente por el escenario y bambalinas, aunque si no la encuentra recorrerá el resto de salas.

El fantasma es capaz de usar palancas y barcas.

Si hay público mirando al escenario (butacas) no puede acceder al mismo.
Para mover al público deberá ir a los palcos a accionar las palancas que tiran las lámparas.

Cuando atrapa a la cantante, la lleva hasta la celda, usando el camino con menor coste (el que tenga más barcas a su favor y evitando al vizconde).

El fantasma soltará a la cantante por voluntad propia o cuando se CHOQUE con el vizconde (en ese momento se queda paralizado varios segundos).

Una vez secuestrada el fantasma vuelve a su sala de música y no volverá a intentar secuestrarla hasta que la cantante se vuelva a situar en el escenario.

Si el fantasma escucha ruidos de golpes en la sala de música (el vizconde golpea sus objetos). Dejará su objetivo principal y volverá a la sala de música.

#### Comportamiento Cantante
Su estancia inicial es el escenario.

Ahí permanecerá gran parte del tiempo, pero cada X segundos, se va a "descansar" a las bambalinas, donde permanece otros segundos.

La cantante podrá ser capturada por el fantasma (no podrá hacer nada).

Cuando el fantasma la suelta, si está en una sala conectada con el escenario, volverá a él. Sin embargo, si no lo está, deambulará por las salas "perdida", en ese caso, si se encuentra con el vizconde irá hacia él para "dejarse salvar".

#### Comportamiento Vizconde
Su estancia inicial es el palco oeste.
Es el personaje que controla el jugador.

Como el fantasma, el vizconde es capaz de interactuar con palancas y lámparas.

Puede chocar con el fantasma para que suelte a la cantante.

Puede golpear muebles en la sala de música para atraer al fantasma.

Puede interactuar con la cantante para llevarla en brazos para devolverla al escenario.

Además, si la cantante está en la celda, debe accionar a la palanca para quitar las rejas.

Cuando el fantasma tira las lámparas es el encargado de volver a dar a la palanca para colocarlas

#### Comportamiento Público
Su estancia inicial son las butacas, hay 2 bloques, izquierda y derecha.

Encima tienes las famosas lámparas. Si el fantasma tira una lámpara (ejemplo izquierda), el público de la izquierda saldrá corriendo al vestíbulo.
No volverán a las butacas hasta que le vizconde haya vuelvo a colocar las lámparas.

### Requisitos prototipo
#### A-------------------------
Representar el escenario (Hecho en punto de partida).

Control del vizconde, movimiento e interacción (Hecho en punto de partida).

Seguimiento de personajes con diferentes cámaras.
#### B-------------------------
Comportamiento del público (Hecho en punto de partida).
#### C-------------------------
Comportamiento de la cantante.

En el punto de partida está implementado la ida y vuelta del escenario a las bambalinas y que desde cualquier punto accesible pueda volver al escenario.

Faltaría hacer que la puedan mover los otros 2 personajes y el merodeo en zonas sin acceso directo al escenario.
#### D-------------------------
Desarrollar el arbol de comportamientos completo del fantasma.

En el punto de partida vienen los comportamientos pero no las transiciones entre ellos.
#### E-------------------------
Usar un sistema de gestión sensorial para que el fantasma reaccione realmente a lo que
ve (en la propia estancia o estancias vecinas visibles) y lo que oye (el canto de su musa
y el ruido de la sala de música), sin tener que recurrir a información privilegiada
(únicamente recordando lo que ha visto anteriormente).

## PUNTO DE PARTIDA

El punto de partida contiene una serie de personajes cuyo comportamiento está implementado mediante máquinas de estados:

### CANTANTE

Tendrá dos estados posibles: Cantando y descansando. La máquina de estados estará controlada por el script Cantante.

#### Estado Cantando

Cuando entra en este estado, se desplaza a la cantante a la posición del escenario y se invoca al método Cantar, que pone el contador del tiempo

transcurrido desde que se empezó a cantar a 0 y situa el booleano que indica si está cantando a true.

Para comprobar si debe permanecer en este estado se utiliza el método TerminaCantar, que aumenta el tiempo desde que se comenzó a cantar siempre y 

cuando la cantante esté dentro del escenario. Da paso al estado Descansando cuando este tiempo sea mayor que el tiempo máximo de canto.

#### Estado Descansando

Al entrar en este estado, la cantante se mueve a las bambalinas y se invoca al método Descansar, que situa el booleano que indica si está cantando a false y 

pone el contador del tiempo transcurrido desde que se empezó a descansar a 0.

Para comprobar si debe permanecer en este estado se utiliza el método TerminaDescansar, que aumenta el tiempo desde que se comenzó a descansar siempre y 

cuando la cantante esté dentro del escenario. Da paso al estado Cantando cuando este tiempo sea mayor que el tiempo máximo de descanso.

### PÚBLICO

Los miembros del público tienen una máquina de estados controlada por el script Publico y que tiene dos estados: En Butacas y En Vestíbulo.

#### Estado En Butacas

Al entrar en este estado se desplaza al público a la posición de las butacas. Permanecerá allí hasta que se apagen las luces.

#### Estado En Vestíbulo

Al entrar en este estado el público se mueve a la posición del vestíbulo. Se moverá de allí cuando se enciendan las luces.

#### Transición entre estados

Para comprobar si se debe cambiar de estados se llama al método getLuces, que devuelve un booleano indicando si el público debe estar sentado.

Cuando las luces se apagan o se encienden por acción del vizconde o el fantasma, se invoca al método apagaLuz o al método enciendeLuz según corresponda. 

apagaLuz pone el booleano que será devuelto por getLuces a false, mientras que enciendeLuz lo pone a true.

## PROPUESTA DE IMPLEMENTACIÓN 
El mayor problema a implementar es el árbol de comportamientos del fantasma, aquí se plentea un diagrama del árbol.

### FANTASMA
![Diagrama Opera](https://github.com/IAV22-G05/P3/blob/main/Assets/Imagenes/ArbolDecisionFantasma.jpg)

## REFERENCIAS
-Documentación árboles de comportamientos: https://opsive.com/support/documentation/behavior-designer/conditional-aborts/
-AI_for_Games_third_edition_2019_Ian_Millington
