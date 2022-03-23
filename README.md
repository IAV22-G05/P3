# INTELIGENCIA ARTIFICIAL PARA VIDEOJUEGOS - PRÁCTICA 3 - GRUPO 05

Sergio Molinero Aparicio - Andrés Carnicero Esteban

Video: 

Resumen de objetivos.

## PUNTO DE PARTIDA
Estas son las clases ya implementadas al comienzo de la práctica.

## RESOLUCION DE LA PRACTICA

En este apartado se explica el enunciado y requisitos del prototipo y el diseño de su implementación.

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


