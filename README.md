vector3d
========

Double precision Vector Libraries for Unity3D

### Non Standard Methods

#### Vector2d.Similar / Vector3d.Similar
`public bool Similar(Vector3d other, double epsilon = EPSILON)`

Tests the vector componentwise for similarity.

#### Vector3d.Rotated
`public Vector3d Rotated(Quaternion rotation)`

Workaround for the construct: `Quaternion * Vector3d`