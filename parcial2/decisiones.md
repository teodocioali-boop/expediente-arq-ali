# Decisiones - Parcial 2 (Variante B - Gimnasio Fuerza Andina)

### Situación 1
**Patrón:** Observer.
**Por qué:** El módulo de socios está acoplado a los servicios de WhatsApp, registro y recepción. Cada vez que se agrega un nuevo interesado (como el módulo de promociones), hay que abrir el módulo de socios y agregarle una llamada. Con Observer, el socio (sujeto) solo mantiene una lista de observadores y los notifica. Si no lo aplico, el módulo de socios se vuelve un caos de dependencias y hay que recompilarlo cada vez que se agrega un canal de aviso.

### Situación 2
**Patrón:** Strategy.
**Por qué:** El cálculo de tarifas vive en un `if/else` duplicado en el módulo de cobros y en el de cotizaciones. El dueño cambia las reglas cada temporada. Con Strategy, encapsulo cada cálculo en una clase (`TarifaManana`, `TarifaNoche`, `TarifaFinDeSemana`) con el mismo contrato. Si no lo aplico, cada cambio de regla obliga a modificar dos módulos y arriesga que lo que se cobra y lo que se cotiza sean inconsistentes.

### Situación 3
**Patrón:** Adapter.
**Por qué:** El SDK del proveedor tiene una interfaz incompatible (`ChargeCard` en inglés, montos en centavos, tokens). No puedo modificar el SDK, pero tampoco quiero que mi dominio dependa de él. Con Adapter, creo un traductor (`PasarelaAdapter`) que implementa mi interfaz `IPasarelaPago` y por dentro llama al SDK. Si el proveedor cambia el próximo año, solo cambio el adaptador, no mi dominio.

**Conexión SOLID (P2.3):**
Mi implementación de la Situación 2 rescata el **Principio de Abierto/Cerrado (OCP)**. Se ve en la línea donde `CobroGimnasio` recibe `ITarifaStrategy` por constructor. Si mañana agrego una tarifa "Feriado", no toco `CobroGimnasio`, solo creo la nueva clase. También aplica **DIP**, porque `CobroGimnasio` depende de la interfaz y no de las clases concretas.