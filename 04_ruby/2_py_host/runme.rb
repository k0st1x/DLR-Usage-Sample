load_assembly "IronPython"

puts "Hello, I am Ruby."

engine = IronPython::Hosting::Python.CreateEngine()
engine.Execute("print('Hello, I am Python.')")