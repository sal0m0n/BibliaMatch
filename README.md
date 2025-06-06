# Juego Iglesia 🎮⛪

Un sistema interactivo de juegos bíblicos desarrollado para actividades de iglesia, que combina una aplicación de escritorio en C# con firmware para microcontroladores PIC creado por Augusto Monge en un fin de semana para un evento de la iglesia (Con mucho espacio de mejora).

## 📋 Descripción

Este proyecto fue desarrollado como una solución casera para dinamizar las actividades de la iglesia mediante juegos interactivos basados en conocimiento bíblico. El sistema incluye:

- **Aplicación de escritorio (BibliaMatch)**: Interfaz principal del juego desarrollada en C# WinForms
- **Sistema de comunicación (BMComm)**: Librería para la comunicación con el hardware
- **Firmware para microcontroladores**: Código para PIC que maneja los dispositivos físicos de entrada
- **Contenido del juego**: Preguntas bíblicas y configuración de grupos

## 🏗 Arquitectura del Proyecto

```
Juego Iglesia/
├── Software/                    # Aplicaciones de escritorio
│   ├── BibliaMatch/            # Aplicación principal del juego
│   │   ├── BibliaMatch/        # Proyecto WinForms principal
│   │   ├── BMComm/             # Librería de comunicación
│   │   ├── Preguntas1.txt      # Base de datos de preguntas (Grupo 1)
│   │   ├── Preguntas2.txt      # Base de datos de preguntas (Grupo 2)
│   │   └── grupos.txt          # Configuración de equipos
│   └── *.jpg, *.png           # Recursos gráficos
├── firmware/                   # Código para microcontroladores
│   ├── iglesia/               # Proyecto principal PIC
│   └── pic12_iglesia/         # Versión alternativa PIC12
├── Media/                     # Archivos multimedia
│   └── *.JPG                  # Imágenes del proyecto
└── Iglesia/                   # Proyecto adicional MPLAB
```

## 🚀 Características

### Aplicación BibliaMatch
- **Interfaz gráfica intuitiva** desarrollada en WinForms
- **Sistema de equipos**: Soporte para múltiples grupos participantes
- **Base de preguntas bíblicas**: Dos conjuntos de preguntas precargadas
- **Comunicación con hardware**: Integración con dispositivos físicos mediante puerto serie
- **Gestión de puntajes**: Sistema de puntuación automático

### Equipos Participantes
El sistema está configurado para los siguientes equipos:
- Guerreros del Señor
- Portales del Cielo
- Infantería del León
- Los Guerreros de Dios
- Los Bienaventurados
- Piedra angular del Este

### Hardware (Firmware PIC)
- **Soporte para microcontroladores PIC**: Código optimizado para PIC16 y PIC12
- **Gestión de interrupciones**: Manejo eficiente de eventos de entrada
- **Comunicación serie**: Protocolo de comunicación con la aplicación PC
- **Temporizadores**: Sistema de timing preciso para el juego

## 🛠 Tecnologías Utilizadas

### Software
- **Lenguaje**: C# (.NET Framework)
- **IDE**: Visual Studio
- **Interfaz**: Windows Forms
- **Comunicación**: Puerto Serie (Serial Port)

### Hardware/Firmware
- **Microcontroladores**: PIC16/PIC12 (Microchip)
- **IDE**: MPLAB X IDE
- **Compilador**: XC8
- **Lenguaje**: C (embedded)

## 📦 Instalación y Configuración

### Prerrequisitos
- Windows 7 o superior
- .NET Framework 4.0 o superior
- Visual Studio 2017 o superior (para desarrollo)
- MPLAB X IDE (para desarrollo de firmware)
- XC8 Compiler (para compilar firmware PIC)

### Compilación del Software
1. Abrir `Software/BibliaMatch/BibliaMatch.sln` en Visual Studio
2. Restaurar paquetes NuGet si es necesario
3. Compilar la solución en modo Release
4. Los ejecutables se generarán en las carpetas `bin/Release/`

### Programación del Firmware
1. Abrir el proyecto en MPLAB X IDE
2. Seleccionar el microcontrolador objetivo
3. Compilar el proyecto
4. Programar el microcontrolador usando un programador compatible (PICkit, etc.)

## 🎮 Uso del Sistema

1. **Preparación del Hardware**: 
   - Conectar los dispositivos PIC programados al puerto serie del PC
   - Verificar la comunicación serie

2. **Iniciar la Aplicación**:
   - Ejecutar `BibliaMatch.exe`
   - Configurar el puerto serie apropiado
   - Cargar las preguntas desde los archivos de texto

3. **Configurar el Juego**:
   - Seleccionar los equipos participantes
   - Configurar las reglas de puntuación
   - Iniciar la sesión de juego

4. **Durante el Juego**:
   - Las preguntas se muestran en pantalla
   - Los equipos responden usando los dispositivos físicos
   - El sistema registra automáticamente las respuestas y puntajes

## 📁 Archivos de Configuración

### Preguntas del Juego
- `Preguntas1.txt`: Primer conjunto de preguntas bíblicas
- `Preguntas2.txt`: Segundo conjunto de preguntas bíblicas
- `grupos.txt`: Lista de equipos participantes

### Formato de Preguntas
```
Pregunta: [Texto de la pregunta]
Respuesta: [Respuesta correcta]
---
```

## 🔧 Desarrollo y Personalización

### Añadir Nuevas Preguntas
1. Editar los archivos `Preguntas1.txt` o `Preguntas2.txt`
2. Seguir el formato establecido
3. Reiniciar la aplicación para cargar los cambios

### Modificar Equipos
1. Editar el archivo `grupos.txt`
2. Añadir o modificar nombres de equipos (uno por línea)
3. Recompilar la aplicación si es necesario

### Personalizar Hardware
1. Modificar el código fuente en `firmware/iglesia/`
2. Ajustar las configuraciones de pines según el hardware
3. Recompilar y reprogramar los microcontroladores

## 🖼 Recursos Gráficos

El proyecto incluye varios recursos visuales:
- Logos y elementos gráficos de la interfaz
- Plantillas (stencils) para el diseño
- Fotografías del sistema en funcionamiento

## 🤝 Contribuciones

Este es un proyecto de código abierto desarrollado para la comunidad. Las contribuciones son bienvenidas:

1. Fork del repositorio
2. Crear una rama para tu característica (`git checkout -b feature/nueva-caracteristica`)
3. Commit de tus cambios (`git commit -am 'Añadir nueva característica'`)
4. Push a la rama (`git push origin feature/nueva-caracteristica`)
5. Crear un Pull Request

## 📝 Notas del Desarrollador

- Este proyecto fue desarrollado como una solución casera para actividades de iglesia
- El código puede necesitar ajustes según el hardware específico utilizado
- Se recomienda probar completamente antes de usar en eventos importantes
- El sistema ha sido probado en entornos Windows

## 📄 Licencia

Este proyecto es de código abierto y está disponible bajo licencia MIT. Siéntete libre de usar, modificar y distribuir según tus necesidades.

