# Design Patterns - Code Examples

This repository contains before and after code examples for 8 essential design patterns.

## Pattern Structure

Each pattern folder contains:
- **Before**: Code demonstrating the problem without the pattern
- **After**: Refactored code using the design pattern
- **Program.cs**: Demonstration comparing both approaches

## Patterns Included

### 1. Strategy Pattern (`/Strategy`)
**Problem**: Multiple algorithms, need to switch between them
**Solution**: Encapsulate algorithms in separate classes
**Examples**: 
- `ShippingCalculator` - Before/After refactoring with different shipping methods
- `MiniDuckSimulator` - Duck behaviors (fly, quack)

### 2. Observer Pattern (`/Observer`)
**Problem**: Multiple objects need to react to state changes
**Solution**: One-to-many dependency with automatic notification
**Example**: `WeatherStation` - Weather data with multiple displays (✅ Already implements pattern)

### 3. Factory Pattern (`/Factory`)
**Problem**: Complex object creation, tight coupling
**Solution**: Encapsulate object creation logic in factory methods
**Examples**:
- `PizzaStoreComparison` - Before/After with NY and Chicago styles
- `PizzaStoreSimpleFactory` - Simple factory implementation
- `PizzaStoreFactoryMethod` - Full factory method pattern
- `PizzaStoreAbstractFactory` - Abstract factory for ingredient families

### 4. State Pattern (`/State`)
**Problem**: Complex conditional logic based on state, behavior changes with state
**Solution**: Encapsulate state-specific behavior in separate state classes
**Examples**:
- `Starter/Gumball` - Original code with switch statements (BEFORE)
- `Solution/Gumball` - State pattern implementation (AFTER)
- `Starter/XMasLights` - Original code with enums and switches (BEFORE)
- `Solution/XMasLights` - State pattern implementation (AFTER)

### 5. Decorator Pattern (`/Decorator`)
**Problem**: Need to add responsibilities dynamically without class explosion
**Solution**: Wrap objects with decorator objects that add functionality
**Example**: Coffee shop with various add-ons (milk, sugar, whipped cream)

### 6. Singleton Pattern (`/Singleton`)
**Problem**: Need exactly one instance of a class (e.g., logger, configuration)
**Solution**: Private constructor + static instance with thread-safe access
**Example**: Application logger shared across all services

### 7. Command Pattern (`/Command`)
**Problem**: Need undo/redo, command queuing, or request logging
**Solution**: Encapsulate requests as objects
**Example**: Text editor with undo/redo functionality

### 8. Template Method Pattern (`/TemplateMethod`)
**Problem**: Multiple classes with similar algorithm structure
**Solution**: Define algorithm skeleton in base class, let subclasses override specific steps
**Example**: Data processors (CSV, JSON, XML) with common processing steps

## How to Run

Each pattern has its own Visual Studio solution:

```bash
# Strategy Pattern
cd Strategy/ShippingCalculator
dotnet run

# State Pattern - Gumball Machine
cd State/Solution/Gumball
dotnet run

# State Pattern - Christmas Lights
cd State/Solution/XMasLights
dotnet run

# Factory Pattern
cd Factory/PizzaStoreComparison
dotnet run

# Decorator Pattern
cd Decorator/CoffeeShop
dotnet run

# Singleton Pattern
cd Singleton/Logger
dotnet run

# Command Pattern
cd Command/TextEditor
dotnet run

# Template Method Pattern
cd TemplateMethod/DataProcessor
dotnet run
```

## Pattern Details

### Strategy Pattern
- **Open/Closed Principle**: New strategies don't require modifying context
- **Runtime flexibility**: Switch algorithms at runtime
- **Encapsulation**: Each algorithm in its own class

### Observer Pattern
- **Loose coupling**: Subject doesn't know concrete observers
- **Dynamic subscription**: Add/remove observers at runtime
- **Broadcast**: One-to-many communication

### Factory Pattern
- **Dependency Inversion**: Depend on abstractions, not concrete classes
- **Encapsulation**: Object creation logic hidden
- **Extensibility**: Easy to add new product types

### State Pattern
- **Eliminate conditionals**: No more complex switch statements
- **Single Responsibility**: Each state handles its own behavior
- **Open/Closed**: Add new states without modifying existing code
- **Clear transitions**: State changes are explicit

### Decorator Pattern
- **Open/Closed Principle**: Open for extension, closed for modification
- **Composition over inheritance**: Add behavior without subclassing
- **Flexible combinations**: Mix and match decorators

### Singleton Pattern
- **Thread-safe**: Double-check locking or Lazy<T>
- **Global access**: Single point of access
- **Resource efficiency**: One instance shared across application

### Command Pattern
- **Encapsulation**: Request as object
- **Undo/Redo**: Execute and reverse operations
- **History**: Track command execution
- **Decoupling**: Separate sender from receiver

### Template Method Pattern
- **Code reuse**: Algorithm structure defined once
- **Standardization**: All subclasses follow same sequence
- **DRY principle**: Don't repeat yourself
- **Hooks**: Optional override points

## SOLID Principles Applied

| Pattern | SOLID Principles |
|---------|------------------|
| Strategy | OCP (new algorithms), DIP (depend on interface) |
| Observer | OCP (new observers), DIP (loose coupling) |
| Factory | OCP (new products), DIP (abstract creation) |
| State | SRP (each state), OCP (new states) |
| Decorator | OCP (extend without modification), SRP |
| Singleton | DIP (single access point) |
| Command | SRP (request encapsulation), OCP (new commands) |
| Template Method | OCP (extend algorithm), DIP (depend on abstract) |

## Before vs After Summary

### Strategy Pattern (ShippingCalculator)
- **Before**: Switch statement in Calculate method
- **After**: Separate strategy classes for each shipping method
- **Benefit**: Easy to add new shipping methods without modifying existing code

### State Pattern (Gumball & XMasLights)
- **Before**: Complex if/switch statements checking state in every method
- **After**: State interface with concrete state classes
- **Benefit**: Each state encapsulated, clear transitions, no conditionals

### Factory Pattern (PizzaStore)
- **Before**: Direct instantiation with if/else chains
- **After**: Factory method in subclasses creates specific products
- **Benefit**: Easy to add new pizza styles (NY, Chicago), follows OCP

## Learning Resources

- **Study Guide**: See `study-guide.md` for comprehensive explanations
- **Head First Design Patterns**: Classic book with detailed examples
- **Practice**: Try modifying the examples to add new features

## Tips for Exam

1. **Recognize patterns** from code structure:
   - Decorator: Wrapper classes with same interface
   - Singleton: Private constructor + static instance
   - Command: Request as object with Execute/Undo
   - Template Method: Abstract base with template method

2. **Know when to apply** each pattern:
   - Decorator: Add behavior without modification
   - Singleton: Single instance needed
   - Command: Undo/redo or request queuing
   - Template Method: Similar algorithms, different steps

3. **Understand relationships** with SOLID principles

4. **Practice refactoring**: Convert Before code to After code
